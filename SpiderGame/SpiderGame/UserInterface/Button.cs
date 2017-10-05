using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderGame
{
    class Button
    {
        Rectangle bPosition;
        Color bColor = Color.Wheat;
        public Texture2D bSprite;
    
        //When the player clicks on the button, it changes the gamestate to the state of the button.
        //Example: If the button's gamestate is menu, clicking on it will change Game1's state to menu. 
        Game1.GameState buttonState;
        

        //Give the button a position, a size, and a gamestate.
        public Button(int xpos, int ypos, int width, int height, Game1.GameState gS)
        {
            bPosition = new Rectangle(xpos, ypos, width, height);
            buttonState = gS;
        }

        //If the cursor is hovering over the button: change the color of the button to something else.
        //If the cursor clicks on the button: change the color and change the gamestate of Game1 to something else.
        public void CheckCollision(Cursor c, bool click)
        {

                if (c.position.Intersects(bPosition) && click)
                {
                    bColor = Color.Black;
                    Game1.gameState = buttonState;
                    //Sound.ButtonClick.Play();
                    Thread.Sleep(500);
                }
                else if (c.position.Intersects(bPosition))
                {
                    bColor = Color.Blue;
                }
                else
                {
                    bColor = Color.White;
                }

        }

        public void Draw(SpriteBatch sB)
        {
            sB.Draw(bSprite, bPosition, bColor);
        }
    }
}
