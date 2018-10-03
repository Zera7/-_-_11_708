using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.MapObjects
{
    public interface IHaveArmy
    {
        Army Army { get; set; }
    }

    public interface IHaveOwner
    {
        int Owner { get; set; }
    }

    public interface IHaveTreasure
    {
        Treasure Treasure { get; set; }
    }

    public abstract class InteractiveObject
    {
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

        private void InteractArmy(Player player)
        {
            if (!player.CanBeat(((IHaveArmy)this).Army))
                player.Die();
        }
        private void InteractOwner(Player player) => ((IHaveOwner)this).Owner = player.Id;
        private void InteractTreasure(Player player) => player.Consume(((IHaveTreasure)this).Treasure);
    }

    public class Dwelling : InteractiveObject, IHaveOwner
    {
        public int Owner { get; set; }
    }

    public class Mine : InteractiveObject, IHaveArmy, IHaveOwner, IHaveTreasure
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    public class Creeps : InteractiveObject, IHaveArmy, IHaveTreasure
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    public class Wolfs : InteractiveObject, IHaveArmy
    {
        public Army Army { get; set; }
    }

    public class ResourcePile : InteractiveObject, IHaveTreasure
    {
        public Treasure Treasure { get; set; }
    }

    public static class Interaction
    {
        public static void Make(Player player, object mapObject)
        {
            if (mapObject is InteractiveObject)
                ((InteractiveObject)mapObject).Interact(player);
        }
    }
}