using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermansServer
{
    public struct Coords2D
    {
        public Coords2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        int x;
        int y;
    }
    public struct Coords2DDouble
    {
        public Coords2DDouble(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        double x;
        double y;
    }

    public enum Directions
    {
        Up,
        Right,
        Down,
        Left
    }
    public enum ServerToClientCommands
    {
        ConfirmConnection,      // Подтвердить подключение
        CancelConnection,       // Отклонить подключение клиента (если превышено max-количество активных лобби)
        SendMap,                // Отправить карту (Происходит единожды перед игрой)
        StartGame,              // Начать игру (после этой команды у клиентов должен появиться отсчет до начала игры)
        UpdateMap,              // Отправить обновления карты (передается одним набором данных: ячейка-новая ячейка, например: координата-пустота, координата-бонус)
        UpdateStats,            // Отправить обновления статов игрока (Например: Speed +1, Bombs +2, может быть несколько подряд)
        StartPlayerMoving,      // Отправить идентификатор игрока и направление движения
        EndPlayerMoving,        // Отправить идентификатор игрока и координаты остановки
        ActivateBomb            // Взорвать бомбу
    };
    public enum ClientToServerCommands
    {
        CreateLobby,            // Создать лобби 
        GetLobbiesList,         // Получить список открытых лобби
        ConnectToGame,          // Запрос на подключение к лобби
        Disconnect,             // Отключение
        StartMoving,            // Начать движение (передается направление)
        EndMoving,              // Закончить движение
        BombPlanted,            // Поставить бомбу
        MineActivated,          // Активировать мину
        GetMapsList,            // Получить список доступных карт
        DownloadMaps,           // Загрузить все карты
    }
    public enum Cells
    {
        Empty = 48,
        Sand,
        Rock,
        Spawn,
        Bonus,
        Bomb,
        Fire
    }
    public enum Bonuses
    {
        RandomStat,
        last
    }
    public enum Bombs
    {
        Default,
        Powerful,
        Mine
    }
}
