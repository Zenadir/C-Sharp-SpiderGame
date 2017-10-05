using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpiderGame
{
    //
    //Custom 2D Camera
    //
    //It applies transformations to the viewport in order to follow the player position
    //
    public class Camera2
    {
        #region Properties

        private readonly Viewport _viewport;

        public Vector2 Position { get; set; }

        //not in use at the moment
        public float Rotation { get; set; }

        public float Zoom { get; set; }

        //center of the screen
        public Vector2 Origin { get; set; }

        #endregion Properties
        //Set the viewport equal to the viewport from Game1
        //The position changes to follow the player. 
        public Camera2(Viewport viewport)
        {
            _viewport = viewport;

            Rotation = 0;
            Zoom = 0.5f;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            Position = Vector2.Zero;
        }

        //Creates a transformation matrix.
        //It is called only on the draw method on game1.
        //It is applied to the spritebatch
        //We currently do not use all of its potential. Still planning
        //Everything besides the rotation matrix is essential.
        public Matrix GetViewMatrix()
        {
            return 
                Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }

        
        //keep the camera centered on the position of the player.
        public void MoveCamera(Rectangle plr)
        {
            Position = new Vector2(plr.Center.X - Origin.X, plr.Center.Y - Origin.Y);
        }
    }
}
