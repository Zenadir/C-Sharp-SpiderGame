using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class Program
    {
        public Program()
        {
            Sprogress = SProgress.Step1;
            Oprogress = OProgress.Step1;
            gamestate = GameState.Question;
            quit = true;
        }
        static Random rng = new Random();
        enum SProgress
        {
            Step1,
            Step2,
        }
        static SProgress Sprogress = SProgress.Step1;

        enum OProgress
        {
            Step1,
            Step2,
        }
        static OProgress Oprogress = OProgress.Step1;

        enum GameState
        {
            Question,
            Code
        }
        static GameState gamestate = GameState.Question;

        static bool quit;

        static void Main(string[] args)
        {
            int input = 0;

            do
            {

                switch (gamestate)
                {
                    case GameState.Question:
                        Console.WriteLine("1: Create Spawner List");
                        Console.WriteLine("2: Create Obstacle List");
                        Console.WriteLine("3: Exit");
                        Console.WriteLine();
                        string SInput = Console.ReadLine();
                        
                        int.TryParse(SInput, out input);
                        gamestate = GameState.Code;
                        break;

                    case GameState.Code:

                        switch (input)
                        {
                            case 1:
                                List<Spawner> SList = new List<Spawner>();
                                Console.WriteLine("How many spawners?");
                                string input1 = Console.ReadLine();
                                int SpawnAmount;
                                int.TryParse(input1, out SpawnAmount);
                                for (int i = 0; i < SpawnAmount; i++)
                                {
                                    
                                    Spawner spawn = new Spawner() { name = "Spawner" + (i + 1) };
                                    
                                    while (true)
                                    {
                                        Console.WriteLine(spawn.name + ": X | # or rng");
                                        string input1X = Console.ReadLine();
                                        int X = 10000;
                                        bool A = int.TryParse(input1X, out X);

                                        if (A == true)
                                        {
                                            spawn.positionX = X;
                                            break;
                                        }
                                        else if (input1X == "rng")
                                        {
                                            spawn.positionX = rng.Next(-50, 51);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in X setting");
                                        }
                                    }
                                                                        
                                    while (true)
                                    {
                                        Console.WriteLine(spawn.name + ": Y | # or rng");
                                        string input1Y = Console.ReadLine();
                                        int Y = 10000;
                                        bool B = int.TryParse(input1Y, out Y);

                                        if (B == true)
                                        {
                                            spawn.positionY = Y;

                                            break;
                                        }
                                        else if (input1Y == "rng")
                                        {
                                            spawn.positionY = rng.Next(-50, 51);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in Y setting");
                                        }
                                    }
                                    SList.Add(spawn);
                                }
                                using (StreamWriter writer = new StreamWriter("../../Spawner.txt", false))
                                {
                                    writer.WriteLine("Obstacle List");

                                    foreach (var item in SList)
                                    {
                                        writer.WriteLine(string.Format("{0} {1} {2}", item.name, item.positionX, item.positionY));
                                    }
                                }
                                gamestate = GameState.Question;
                                break;

                            case 2:
                                List<Obstacle>OList = new List<Obstacle>();
                                Console.WriteLine("How many Obstacles?");
                                string input2 = Console.ReadLine();
                                int ObstacleAmount;
                                int.TryParse(input2, out ObstacleAmount);
                                for (int i = 0; i < ObstacleAmount; i++)
                                {

                                    Obstacle Ob = new Obstacle() { name = "Obstacle" + (i + 1) };

                                    while (true)
                                    {
                                        Console.WriteLine(Ob.name + ": X | # or rng");
                                        string input2X = Console.ReadLine();
                                        int X = 10000;
                                        bool A = int.TryParse(input2X, out X);

                                        if (A == true)
                                        {
                                            Ob.positionX = X;
                                            break;
                                        }
                                        else if (input2X == "rng")
                                        {
                                            Ob.positionX = rng.Next(-50, 51);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in X setting");
                                        }
                                    }

                                    while (true)
                                    {
                                        Console.WriteLine(Ob.name + ": Y | # or rng");
                                        string input2Y = Console.ReadLine();
                                        int Y = 10000;
                                        bool B = int.TryParse(input2Y, out Y);

                                        if (B == true)
                                        {
                                            Ob.positionY = Y;

                                            break;
                                        }
                                        else if (input2Y == "rng")
                                        {
                                            Ob.positionY = rng.Next(-50, 51);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in Y setting");
                                        }
                                    }

                                    OList.Add(Ob);
                                }
                                using (StreamWriter writer = new StreamWriter("../../Obstacle.txt", false))
                                {
                                    writer.WriteLine("Obstacle List");
                                    foreach (var item in OList)
                                    {
                                        writer.WriteLine(string.Format("{0} {1} {2}", item.name, item.positionX, item.positionY));
                                    }                                    
                                }
                                gamestate = GameState.Question;
                                break;

                            case 3:
                                quit = true;
                                
                                break;

                            default:
                                break;
                        }


                        break;
                    
                }
                StreamWriter writer3 = new StreamWriter("../../Test.txt", true);
                writer3.Write("Test");
                writer3.Close();



            } while (quit != true);            
        }
    }
}
