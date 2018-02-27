namespace Mazes
{
    public static class SnakeMazeTask
    {
        static void MoveInTheDirectionOf(Mazes.Direction directionOfMove, int length, Robot robot)
        {
            for (int i = 0; i < length; i++) robot.MoveTo(directionOfMove);
        }

        public static void MoveOut(Robot robot, int width, int height)
        {
            int len = (height - 1) / 2;
            for (int i = 0; i < len; i++)
            {
                if (i > 0)
                {
                    robot.MoveTo(Direction.Down);
                    robot.MoveTo(Direction.Down);
                }

                MoveInTheDirectionOf(((i % 2) == 0) ? Direction.Right : Direction.Left, width - 3, robot);
            }

        }
    }
}