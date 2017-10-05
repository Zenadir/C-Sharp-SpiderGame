
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using Editor;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace SpiderGame
{
    class Lists
    {
        //Lists to hold enemies created by spawners
        public static List<Enemies> AllEnemies = new List<Enemies>();

        //Lists to hold the bullets spawned by the player and enemies.
        public static List<Bullet> EnemyBullets = new List<Bullet>();
        public static List<Bullet> PlayerBullets = new List<Bullet>();

        //A list to hold spawners
        public static List<Spawner> AllSpawners = new List<Spawner>();

        //List to hold Obstacles
        public static List<Obstacle> AllObstacles = new List<Obstacle>();

        //Lists of menus
        public static List<Texture2D> Menus = new List<Texture2D>();

        //List with all UI buttons
        public static List<Texture2D> Buttons = new List<Texture2D>();

        //List with all sounds
        public static List<Song> Songs = new List<Song>();
        public static List<SoundEffect> SoundEffects = new List<SoundEffect>();

        //Lists to hold Textures. This allows gameobjects to assign their own textures in their constructors.
        public static Texture2D PlayerTexture;

        //Holds the turret sprite
        public static Texture2D TurretTexture;

        //Holds the sprite for the fiddler enemy.
        public static Texture2D FiddlerSprite;

        public static List<Texture2D> BaseEnemyTexture;
        public static List<Texture2D> BulletTextures;

        //Holds the texture for the enemy bullet
        public static Texture2D EnemyBulletTexture;

        //Holds the texture for the obstacle
        public static Texture2D ObstaclesTexture;

        //The sprite for the main menu background
        public static Texture2D MainMenuTexture;

        //The sprite for the pause menu background
        public static Texture2D PauseMenuTexture;

        //The sprite for the button used to return to the main
        //menu from the pause menu
        public static Texture2D GiveUpButtonTexture;

        //The sprite for the button used to return to the main
        //game from the pause menu
        public static Texture2D ContinueButtonTexture;

        //The texture for the spawner
        public static Texture2D SpawnerTexture;

        //The font used to display the current wave and score.
        public static SpriteFont BasicFont;

        //The texture for the floor
        public static Texture2D FloorTexture;

        //A method that clears all lists
        public static void Reset()
        {
            //Clear enemies
            AllEnemies.Clear();

            //Clear bullets
            EnemyBullets.Clear();
            PlayerBullets.Clear();

            //Clear obstacles
            AllObstacles.Clear();

            //Reset the spawners using the external editor
            Thread ResetSpawn = new Thread(StaticMethods.Reset);
            ResetSpawn.Start();
            ResetSpawn.Join();

            //Reset the obstacles using the external editor
            Thread ResetObj = new Thread(StaticMethods.ResetO);
            ResetObj.Start();
            ResetObj.Join();

            //Read in the obstacles and spawners from the external editor
            AllSpawners = StaticMethods.ReadInSpawner();
            AllObstacles = StaticMethods.ReadInObstacle();

        }

        //Load content into all of their respective lists
        public static void LoadLists(ContentManager Content)
        {
            BaseEnemyTexture = SeparateLoad.LoadEnemies(Content);
            BulletTextures = SeparateLoad.LoadBullets(Content);
            Buttons = SeparateLoad.LoadButtons(Content);
            Menus = SeparateLoad.LoadMenus(Content);
            Songs = SeparateLoad.LoadSongs(Content);     
            AllSpawners = StaticMethods.ReadInSpawner();
            AllObstacles = StaticMethods.ReadInObstacle();
            SoundEffects = SeparateLoad.LoadSounds(Content);
        }

        //Constants used to set the maximum amount of enemies & bullets that should be on screen at any given time. 
        public const int MAX_E_BULLETS = 30;
        public const int MAX_P_BULLETS = 50;
        public const int MAX_SCREEN_ENEMIES = 20;

        //Calls the update function of the enemies and bullets.
        //Calls ClearWaste
        static public void Update(Player p)
        {

            foreach (Enemies eN in AllEnemies)
            {
                eN.Update(p.position);
            }

            foreach (Bullet item in Lists.PlayerBullets)
            {
                item.Update();
            }

            foreach (Bullet item in Lists.EnemyBullets)
            {
                item.Update(p);
            }

            //Generate from 4 Spawners + 1 more every four waves           
            for (int i = 0; i < (WaveLogic.CurrentWave % 4) + 4; i++)
            {
                AllSpawners[i].Generate();
            }

            ClearWaste(p);
        }

        //Removes objects from their lists if they are no longer in use. 
        static public void ClearWaste(Player p)
        {
            //Foreach enemy in the list of enemies
            for (int i = 0; i < AllEnemies.Count; i++)
            {
                //If the enemy is not active
                if (AllEnemies[i].Active == false)
                {
                    //Subtract 1 from the number of enemies remaining in any given wave.
                    --WaveLogic.EnemiesRemaining;
                    

                    //Add an amount of points to the players score equal to however many
                    //points that enemy is worth.
                    p.Score += AllEnemies[i].ScoreReward;

                    //Remove the enemy from the list
                    AllEnemies.Remove(AllEnemies[i]);
                }
            }

            //If bullets are not active, remove them from the list
            for (int i = 0; i < PlayerBullets.Count; i++)
            {

                if (!PlayerBullets[i].Active)
                {
                    PlayerBullets.RemoveAt(i);
                }
            }

            for (int i = 0; i < EnemyBullets.Count; i++)
            {

                if (!EnemyBullets[i].Active)
                {
                    EnemyBullets.RemoveAt(i);
                }
            }
        }



        //Draw objects in the lists
        static public void DrawEnemies(SpriteBatch sB)
        {
            //Draw Callculated Ammount
            for (int i = 0; i < (WaveLogic.CurrentWave % 4) + 4; i++)
            {
                AllSpawners[i].Draw(sB);

                //sB.Draw(AllSpawners[i].sprite, AllSpawners[i].position, Color.White);
            }
            foreach (Obstacle obst in AllObstacles)
            {
                obst.Draw(sB);
            }

            foreach (Enemies eNem in AllEnemies)
            {

                eNem.Draw(sB);
            }




        }

        //Draw all bullets
        static public void DrawBullets(SpriteBatch sB)
        {

            foreach (Bullet pBul in PlayerBullets)
            {
                pBul.Draw(sB);
            }

            foreach (Bullet eBul in EnemyBullets)
            {
                eBul.Draw(sB);
            }

        }
    }
}

