using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_1
{
    public class FootballClub
    {
        public FootballClub(string name, int wins, int draws, int losses, int goalsScored, int goalsConceded)
        {
            this.Name = name;
            this.Wins = wins;
            this.Draws = draws;
            this.Losses = losses;
            this.GoalsScored = goalsScored;
            this.GoalsConceded = goalsConceded;
        }

        public FootballClub(FootballClub anotherClub)
        {
            this.Name = anotherClub.Name;
            this.Wins = anotherClub.Wins;
            this.Draws = anotherClub.Draws;
            this.Losses = anotherClub.Losses;
            this.GoalsScored = anotherClub.GoalsScored;
            this.GoalsConceded = anotherClub.GoalsConceded;
        }

        public string Name { get; set; }

        public int GamesPlayed { get => Wins + Draws + Losses; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }

        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }

        public override string ToString()
        {
            return $"Название: {Name} \nВсего игр: {GamesPlayed} \nПобед: {Wins} " +
                $"\nПоражений: {Losses} \nНичьих: {Draws} \n" +
                $"Забито: {GoalsScored} \nПропущено: {GoalsConceded}";
        }
    }
}
