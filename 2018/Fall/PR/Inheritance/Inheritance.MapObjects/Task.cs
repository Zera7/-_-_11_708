using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.MapObjects
{
    /// <summary>
    /// Интерфейс для классов, которые имеют поле "Армия"
    /// </summary>
    public interface IHaveArmy
    {
        Army Army { get; set; }
    }

    /// <summary>
    /// Интерфейс для классов, которые имеют поле "Владелец"
    /// </summary>
    public interface IHaveOwner
    {
        int Owner { get; set; }
    }

    /// <summary>
    /// Интерфейс для классов, которые имеют поле "Сокровище"
    /// </summary>
    public interface IHaveTreasure
    {
        Treasure Treasure { get; set; }
    }

    /// <summary>
    /// Абстрактный класс "Объекты с которыми можно взаимодействовать"
    /// Используется когда нужно взаимодействовать с объектом
    /// </summary>
    public abstract class InteractiveObject
    {
        /// <summary>
        /// Метод для взаимодействия игрока с объектом
        /// с которым можно взаимодействовать и который наследуется 
        /// от абстрактного класса "Объекты с которыми можно взаимодействовать"
        /// <param name="player">Объект класса "игрок", который будет взаимодействовать</param>
        public void Interact(Player player)
        {
            if (this is IHaveArmy)
                InteractArmy(player);
            if (player.Dead)
                return;
            if (this is IHaveOwner)
                InteractOwner(player);
            if (this is IHaveTreasure)
                InteractTreasure(player);
        }

        /// <summary>
        /// Скрытый метод "Взаимодействовать с армией"
        /// Нужен для взаимодействия с объектами у которых есть армия 
        /// (объекты реализующие интерфейс IHaveArmy)
        /// </summary>
        /// <param name="player">Объект класса "игрок", который будет взаимодействовать</param>
        private void InteractArmy(Player player)
        {
            if (!player.CanBeat(((IHaveArmy)this).Army))
                player.Die();
        }
        /// <summary>
        /// Скрытый метод "Взаимодействовать с владельцем"
        /// Нужен для взаимодействия с объектами у которых есть владелец 
        /// (объекты реализующие интерфейс IHaveOwner)
        /// </summary>
        /// <param name="player">Объект класса "игрок", который будет взаимодействовать</param>
        private void InteractOwner(Player player) => ((IHaveOwner)this).Owner = player.Id;
        /// <summary>
        /// Скрытый метод "Взаимодействовать с сокровищами"
        /// Нужен для взаимодействия с объектами у которых есть сокровища 
        /// (объекты реализующие интерфейс IHaveTreasure)
        /// </summary>
        /// <param name="player">Объект класса "игрок", который будет взаимодействовать</param>
        private void InteractTreasure(Player player) => player.Consume(((IHaveTreasure)this).Treasure);
    }

    /// <summary>
    /// С объектами этого класса можно взаимодействовать, имеет армию
    /// </summary>
    public class Dwelling : InteractiveObject, IHaveOwner
    {
        public int Owner { get; set; }
    }

    /// <summary>
    /// С объектами этого класса можно взаимодействовать, имеет армию, владельца и сокровища
    /// </summary>
    public class Mine : InteractiveObject, IHaveArmy, IHaveOwner, IHaveTreasure
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    /// <summary>
    /// С объектами этого класса можно взаимодействовать, имеет армию и сокровища
    /// </summary>
    public class Creeps : InteractiveObject, IHaveArmy, IHaveTreasure
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    /// <summary>
    /// С объектами этого класса можно взаимодействовать, имеет армию
    /// </summary>
    public class Wolfs : InteractiveObject, IHaveArmy
    {
        public Army Army { get; set; }
    }

    /// <summary>
    /// С объектами этого класса можно взаимодействовать, имеет сокровища
    /// </summary>
    public class ResourcePile : InteractiveObject, IHaveTreasure
    {
        public Treasure Treasure { get; set; }
    }

    /// <summary>
    /// Открытый статический класс взаимодействие
    /// Существует только для того чтобы проходили тесты
    /// Придуман гениями из СКБ "Контур"
    /// Слишком хорош
    /// </summary>
    public static class Interaction
    {
        /// <summary>
        /// Метод для взаимодействия Объекта класса "игрок" с объектом карты
        /// </summary>
        /// <param name="player">Объект класса "игрок", который будет взаимодействовать</param>
        /// <param name="mapObject">Представляет из себя объект карты
        /// (но так как не реализует никаких интерфейсов - неизвестно, что там)</param>
        public static void Make(Player player, object mapObject)
        {
            if (mapObject is InteractiveObject)
                ((InteractiveObject)mapObject).Interact(player);
        }
    }
}