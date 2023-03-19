using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Project_lebron.src.classes
{
	public class Scenery : AnimacaoSprite
    {
        public Rectangle body = Rectangle.Empty;

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