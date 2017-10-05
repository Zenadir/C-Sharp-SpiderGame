using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gabe_Dworman_Test_Code
{
    //Object Class
    //A generic object class that most other active game objects will inherit from
    //Start Date: 3/2/16
    //Gabryel Dworman
    class GameObject
    {
        public Rectangle Position;
        public Texture2D Texture;

        public bool Active { get; set; }
        public bool checkCollision { get; set; }

        Color objColor = Color.White;
        //A color object that the object can use to change its
        public GameObject(Rectangle pos, Texture2D tex)
        {
            Position = pos;
            Texture = tex;
        }
        //Takes parameters for texture and position
        protected void Draw(SpriteBatch sB)
        {
            sB.Draw(this.Texture, this.Position, this.objColor);
        }
        //A methods for the object to draw itself

        protected void Collision(GameObject gO)
        {
            if(checkCollision == true)
            {
                if (this.Position.Intersects(gO.Position))
                {
                    //Insert code here
                }

            }

        }
        //Used to check collision 
    }
}
