using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Editor
{
    class DrawRectangle : GameObject
    {
        //Object Name
        string name;
        //Rectangle data
        Rectangle shape;
        //Color
        Color color;

        //Constructor
        public DrawRectangle(string n, Rectangle rect, Color c)
        {
            name = n;
            shape = rect;
            color = c;
        }

    }
}
