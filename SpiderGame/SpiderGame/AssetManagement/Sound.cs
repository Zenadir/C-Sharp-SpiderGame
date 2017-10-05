using Editor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpiderGame.UserInterface;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
namespace SpiderGame
{
    class Sound
    {
        static public Song backgroundSong;

        static public SoundEffect ButtonClick;
        //static public SoundEffectInstance backgroundSoundInstance;

        //public static AudioListener listener;
        //public static AudioEmitter emitter;

        public static void Initialize()
        {
            backgroundSong = Lists.Songs[0];
            ButtonClick = Lists.SoundEffects[0];

        }
    }
}
