using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1
{
    class Program
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        static void Main(string[] args)
        {
            //GetGameResult();
        }
        const int WinSequence = 3;
        const int FieldLength = 3;

        //Перебор всех ходов
        static GameResult GetGameResult(Mark[,] field)
        {
            bool crossWin = false;
            bool circleWin = false;
            for (int i = 0; i < WinSequence; i++)
            {
                for (int j = 0; j < WinSequence; j++)
                {
                    if (!crossWin) crossWin = Winner(i, j, Mark.Cross, field);
                    if (!circleWin) circleWin = Winner(i, j, Mark.Circle, field);
                }
            }
            if (crossWin && !circleWin) return GameResult.CrossWin;
            if (!crossWin && circleWin) return GameResult.CircleWin;
            return GameResult.Draw;
        }

        //Проверка хода на победу
        static bool Winner(int yCoord, int xCoord, Mark player, Mark[,] field)
        {
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 || j != 0)
                        if (field[yCoord, xCoord] == player)
                            if (GetLengthOfRow(i, j, yCoord, xCoord, field, player) >= WinSequence - 1)
                                return true;
                }
            return false;
        }

        //Рекурсивная проверка
        static int GetLengthOfRow(int yDirection, int xDirection, int yCoord, int xCoord, Mark[,] field, Mark player)
        {
            if (xDirection + xCoord >= 0 && yDirection + yCoord >= 0 &&
                xDirection + xCoord < FieldLength && yDirection + yCoord < FieldLength)
                if (field[yDirection + yCoord, xDirection + xCoord] == player)
                    return 1 + GetLengthOfRow(
                        yDirection, xDirection, yDirection + yCoord, xDirection + xCoord, field, player);
            return 0;
        }
    }
}
