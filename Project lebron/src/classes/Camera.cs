using Microsoft.Xna.Framework;

namespace Project_lebron.src.classes
{
    public class Camera
    {
        private int _width;
        private int _height;
        public Matrix Transform { get; private set; }

        public Camera(int width, int height)
        {
            this._width = width;
            this._height = height;
        }
       
        public void Follow(BaseObject target)
        {
            Rectangle rect = target.Body;

            var position = Matrix.CreateTranslation( -rect.X - (rect.Width / 2), -rect.Y - (rect.Height / 2), 0);
            var offset = Matrix.CreateTranslation(
                this._width / 2,
                this._height / 2,
                0);
            Transform = position * offset;
        }
    }
}
