using System;

namespace Bowling_ball_Amit
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Bowling game:");
                Console.WriteLine("Enter Y for Random Roll entry else press any key and hit enter");
                string selection = Console.ReadLine();
                BowlingGame game = new BowlingGame();
                if (selection=="Y" || selection == "y")
                {
                    RandomRoll(game);
                }
                else
                {
                    ////SET 1
                    game.Roll(6);
                    game.Roll(4);

                    game.Roll(5);
                    game.Roll(5);

                    game.Roll(1);
                    game.Roll(4);

                    game.Roll(4);
                    game.Roll(5);

                    game.Roll(10);

                    game.Roll(0);
                    game.Roll(1);

                    game.Roll(7);
                    game.Roll(3);

                    game.Roll(6);
                    game.Roll(4);

                    game.Roll(9);
                    game.Roll(1);

                    game.Roll(4);
                    game.Roll(0);
                }
                Console.WriteLine("Score: " + game.GetTotalScore());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }


        private static void RandomRoll(BowlingGame game)
        {
            try
            {
                Random random = new Random();
                int pins;
                int totalpins;
                for (int i = 1; i <= 10; i++)
                {
                    pins = 0;
                    totalpins = 0;
                    pins = random.Next(0, 10);
                    game.Roll(pins);
                    totalpins += pins;
                    if (i < 10)
                    {
                        if (pins < 10)
                        {
                            pins = random.Next(0, 10 - pins);
                            game.Roll(pins);
                        }
                    }
                    else
                    {

                        if (pins < 10)
                        {
                            pins = random.Next(0, 10 - pins);
                            game.Roll(pins);
                            if (totalpins == 10)
                            {
                                pins = random.Next(0, 10);
                                game.Roll(pins);
                            }
                        }
                        else
                        {
                            pins = random.Next(0, 10);
                            game.Roll(pins);
                            pins = random.Next(0, 10);
                            game.Roll(pins);
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
