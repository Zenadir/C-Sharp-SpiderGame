using Editor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpiderGame.UserInterface;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace SpiderGame
{
    class SeparateLoad
    {
        //not in use at this moment
        static List<string> spriteSpiderStrings = new List<string>();
        static Dictionary<string, List<Texture2D>> playerMovement = new Dictionary<string, List<Texture2D>>();


        //Adresses of the files we have under content manager
        static public string[] spriteBulletString =
        {
            "Bullet/Bullet0",
            "Bullet/BulletPlayer",
            "Bullet/EnemyBullet"

        };

        static public string[] spriteEnemyStrings = 
        {
            "Enemies/EnemySprite"
        };

        static public string[] menusStrings =
        {
            "Menus/Screens/deathScreen",
            "Menus/Screens/pauseScreen"
        };

        static public string[] buttonsStrings =
        {
            "Menus/Button/Campaign",
            "Menus/Button/Continue",
            "Menus/Button/exitgame",
            "Menus/Button/ExittoMenu",
            "Menus/Button/startgame",
            "UserInterface/Buttons/ContinueButton",
            "UserInterface/Buttons/GiveUpButton",
            "UserInterface/Buttons/ExitButton",
            "UserInterface/Buttons/StartButton"
        };


        static public string[] songsStrings =
        {
            "Sound/MenusSound"
        };

        static public string[] soundsStrings =
{
            "Sound/Click",
            "Sound/EnemyDeath",
            "Sound/PlayerFiring"
        };

        //load every sound into a list
        static public List<Song> LoadSongs(ContentManager Content)
        {
            List<Song> songs = new List<Song>();
            //soundeffect sound = content.load<soundeffect>("sound/menussound");

            foreach (string str in songsStrings)
            {

                songs.Add(Content.Load<Song>(str));
            }

            return songs;
        }
        static public List<SoundEffect> LoadSounds(ContentManager Content)
        {
            List<SoundEffect> sound = new List<SoundEffect>();
            //soundeffect sound = content.load<soundeffect>("sound/menussound");

            foreach (string str in soundsStrings)
            {

                sound.Add(Content.Load<SoundEffect>(str));
            }

            return sound;
        }
        //loads every enemy sprite into a list



        static public List<Texture2D> LoadEnemies(ContentManager Content)
        {
            List<Texture2D> enemiesTextures = new List<Texture2D>();  
            
            foreach (var item in spriteEnemyStrings)
            {               
                enemiesTextures.Add(Content.Load<Texture2D>(item));
            }

            return enemiesTextures;
        }
        //loads every button into a list
        static public List<Texture2D> LoadButtons(ContentManager Content)
        {
            List<Texture2D> buttonsTextures = new List<Texture2D>();

            foreach (string str in buttonsStrings)
            {
                buttonsTextures.Add(Content.Load<Texture2D>(str));
            }

            return buttonsTextures;
        }
        //loads every menu sprite into a List
        static public List<Texture2D> LoadMenus(ContentManager Content)
        {
            List<Texture2D> menusTextures = new List<Texture2D>();

            foreach (string str in menusStrings)
            {
                menusTextures.Add(Content.Load<Texture2D>(str));
            }
            return menusTextures;
        }
        //loads every Bullet sprite into a List
        static public List<Texture2D> LoadBullets(ContentManager Content)
        {
            List<Texture2D> bulletsTextures = new List<Texture2D>();

            foreach (var item in spriteBulletString)
            {               
                bulletsTextures.Add(Content.Load<Texture2D>(item));
            }

            return bulletsTextures;
        }

        //loads every Spider sprite into a List
        static public List<Texture2D> LoadSpider(ContentManager Content)
        {
            List<Texture2D> spider = new List<Texture2D>();

            foreach (var item in spriteSpiderStrings)
            {               
                spider.Add(Content.Load<Texture2D>(item));
            }

            return spider;
        }
    }
}
