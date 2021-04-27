using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    class Program
    {
        public static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // 75/100 judge
           
        }
    }
}
