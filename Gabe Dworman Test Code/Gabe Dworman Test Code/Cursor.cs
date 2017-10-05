using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gabe_Dworman_Test_Code
{
    class Cursor :GameObject
    {

        MouseState mS = new MouseState();
        public Cursor(Rectangle pos, Texture2D tex): base(pos,tex)
        {
            this.Position = new Rectangle(mS.X, mS.Y, 20, 20);
        }

        public void updatePosition()
        {
            this.Position = new Rectangle(mS.X, mS.Y, 20, 20);
        }

    }
}
