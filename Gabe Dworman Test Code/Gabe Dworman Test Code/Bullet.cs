using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabe_Dworman_Test_Code
{
    class Bullet : GameObject
    {
        public float xDistance { get; set; }
        public float yDistance { get; set; }

        public float
        public Bullet(Rectangle pos, Texture2D tex, Cursor reticle , GameObject player) : base(pos, tex)
        {
            xDistance = reticle.Position.X - player.Position.X;
            yDistance = reticle.Position.Y - player.Position.X; 
            //Gets the difference in distance between the target and the player.

            
        }

        public void Fly()
        {

        }
    }
}
