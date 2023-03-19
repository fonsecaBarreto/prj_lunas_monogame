using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Project_lebron.src.classes
{
	public class Scenery : AnimacaoSprite
    {
        private Rectangle body = new Rectangle(0, 0, 1, 1);
        private Vector2 _tilesDimensions = new Vector2(320, 320);
        private int count = 0;

        public void Mover(ref GameTime gameTime)
        {
            Debug.WriteLine(gameTime.TotalGameTime.Seconds);
            int seconds = gameTime.TotalGameTime.Seconds;
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            Draw(ref spriteBatch, body);
        }

        public Scenery(Rectangle rect)
        {
            body = rect;
        }
    }

}