
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Editor
{
    public class EditorProgram
    {
        public EditorProgram()
        {
            //Initial Gamestate and quit state
            gamestate = GameState.Question;
            quit = false;
        }        
        //Gamestate
        enum GameState
        {
            Question,
            Code
        }
        //Gamestate attribute
        static GameState gamestate;
        //Quitattribute
        static bool quit;
        //Random attribute
        static Random rng = new Random();


        public static void Main(string[] args)
        {
            
            //Creation of input variable
            int input = 0;
            //Editor Loop
            while (quit != true)
            {   
                //Main switch between question and code
                switch (gamestate)
                {
                    case GameState.Question:
                        //Editor options
                        Console.WriteLine("1: Create Spawner List");
                        Console.WriteLine("2: Create Obstacle List");
                        
                        Console.WriteLine("3: Exit");
                        Console.WriteLine();
                        string SInput = Console.ReadLine();
                        //string input to int input
                        int.TryParse(SInput, out input);
                        //Loop and return to Code instead.
                        gamestate = GameState.Code;
                        break;

                    case GameState.Code:

                        switch (input)
                        {
                            case 1:
                                //Spawner:  Create list, How many spawners, take input and parse.
                                List<Spawner> SList = new List<Spawner>();
                                Console.WriteLine("How many spawners?");
                                string input1 = Console.ReadLine();
                                int SpawnAmount;
                                int.TryParse(input1, out SpawnAmount);
                                //For based on input
                                for (int i = 0; i < SpawnAmount; i++)
                                {
                                    //Add spawn object
                                    Spawner spawn = new Spawner() { name = "Spawner" + (i + 1) };
                                    //Loop untill correctly made.
                                    while (true)
                                    {
                                        //X input: Specific or random between -1000 and 1000.  Loop if bad input.
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
                                            spawn.positionX = rng.Next(-1500, 5501);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in X setting");
                                        }
                                    }
                                    //Loop untill Y is set.                                    
                                    while (true)
                                    {
                                        //Y input: Specific or random between -1000 and 1000.  Loop if bad input.

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
                                            spawn.positionY = rng.Next(-1000, 4001);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in Y setting");
                                        }
                                    }
                                    //Add finished spawn to List.
                                    SList.Add(spawn);
                                }
                                //Write directly into Spidergame and always overwrite.
                                using (StreamWriter writer = new StreamWriter("../../../SpiderGame/Spawner.txt", false))
                                {
                                    writer.WriteLine("Spawner List");
                                    //Each line of text represents one spawner.
                                    foreach (var item in SList)
                                    {
                                        writer.WriteLine(string.Format("{0} {1} {2}", item.name, item.positionX, item.positionY));
                                    }
                                }
                                //Switch back to question state for new list if desired.
                                gamestate = GameState.Question;
                                break;

                            case 2:
                                //Obstacle List:  How many.
                                List<Obstacle>OList = new List<Obstacle>();
                                Console.WriteLine("How many Obstacles?");
                                string input2 = Console.ReadLine();
                                int ObstacleAmount;
                                int.TryParse(input2, out ObstacleAmount);
                                for (int i = 0; i < ObstacleAmount; i++)
                                {

                                    Obstacle Ob = new Obstacle() { name = "Obstacle" + (i + 1) };
                                    //X input loop
                                    while (true)
                                    {
                                        //Input: Number or rng.  Loop if neither.
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
                                            Ob.positionX = rng.Next(-1500, 5501);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in X setting");
                                        }
                                    }
                                    // Y input loop
                                    while (true)
                                    {
                                        //Input: Number or rng.  Loop if neither.
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
                                            Ob.positionY = rng.Next(-1000, 4001);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in Y setting");
                                        }
                                    }
                                    //Add finished obstacle
                                    OList.Add(Ob);
                                }
                                //Write directly into Spider Game
                                using (StreamWriter writer = new StreamWriter("../../../SpiderGame/Obstacle.txt", false))
                                {
                                    writer.WriteLine("Obstacle List");
                                    foreach (var item in OList)
                                    {
                                        //Each Obstacle takes up one line of text.
                                        writer.WriteLine(string.Format("{0} {1} {2}", item.name, item.positionX, item.positionY));
                                    }                                    
                                }
                                //Switch back for new list.
                                gamestate = GameState.Question;
                                break;

                           
                            case 3:
                                //Quit on 3 input.
                                quit = true;
                                
                                break;
                                //If Not 1,2, or 3... Error and loop back to question.
                            default:
                                Console.WriteLine("Error in input");
                                gamestate = GameState.Question;
                                break;
                        }
                        //End of Gamestate.Code switch
                        break;                    
                }             
            }             
        }

        public static void Reset()
        {
            int SpawnAmount = -1;
            StreamReader read = new StreamReader("../../../../bin/DesktopGL/x86/Debug/Spawner.txt");
            string line;
            while ((line = read.ReadLine()) != null)
            {
                SpawnAmount++;
            }
            //Spawner:  Create list, How many spawners, take input and parse.
            List<Spawner> SList = new List<Spawner>();
                        
            //For based on input
            for (int i = 0; i < SpawnAmount; i++)
            {
                //Add spawn object
                Spawner spawn = new Spawner() { name = "Spawner" + (i + 1) };

                spawn.positionX = rng.Next(-1500, 5501);

                spawn.positionY = rng.Next(-1000, 4001);
                //Add finished spawn to List.
                SList.Add(spawn);
            }
            read.Close();
            //Write directly into Spidergame and always overwrite.
            using (StreamWriter writer = new StreamWriter("Spawner.txt", false))
            {
                writer.WriteLine("Spawner List");
                //Each line of text represents one spawner.
                foreach (var item in SList)
                {
                    writer.WriteLine(string.Format("{0} {1} {2}", item.name, item.positionX, item.positionY));
                }
            }
        }

        public static void ResetO()
        {
            int ObstacleAmount = -1;
            StreamReader readO = new StreamReader("../../../../bin/DesktopGL/x86/Debug/Obstacle.txt");
            string line;
            while ( (line = readO.ReadLine()) != null)
            {
                ObstacleAmount++;
            }
            //Obstacle List:  How many.
            List<Obstacle> OList = new List<Obstacle>();
            
            for (int i = 0; i < ObstacleAmount; i++)
            {

                Obstacle Ob = new Obstacle() { name = "Obstacle" + (i + 1) };
                //X input loop
                Ob.positionX = rng.Next(-1500, 5501);
                // Y input loop
                Ob.positionY = rng.Next(-1000, 4001);
                //Add finished obstacle
                OList.Add(Ob);
            }
            readO.Close();
            //Write directly into Spider Game
            using (StreamWriter writer = new StreamWriter("../../../../bin/DesktopGL/x86/Debug/Obstacle.txt", false))
            {
                writer.WriteLine("Obstacle List");
                foreach (var item in OList)
                {
                    //Each Obstacle takes up one line of text.
                    writer.WriteLine(string.Format("{0} {1} {2}", item.name, item.positionX, item.positionY));
                }
            }
        }
    }    
}
