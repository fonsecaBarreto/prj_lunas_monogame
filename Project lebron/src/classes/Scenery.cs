using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Project_lebron.src.classes
{
	public class Scenery : BaseObject
    {

        public void Mover(ref GameTime gameTime)
        {
            Debug.WriteLine(gameTime.TotalGameTime.Seconds);
            int seconds = gameTime.TotalGameTime.Seconds;
        }

        public Scenery(Rectangle rect) : base(rect, new Vector2(0f)) { 
        }

    }

}