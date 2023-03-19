

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Project_lebron.src.classes {
    public abstract class Sprite
    {

        public Texture2D _textura;
        public Rectangle _texture_region = Rectangle.Empty;
        private int _texture_total_columns= 0;
        private int _texture_current_column= 0;
        private bool _textrure_repeat= false;
        private TimeSpan accumulate_time = TimeSpan.Zero;

        public void LoadContent(ContentManager content, string assetName, int rows = 1, int cols = 1, bool repeat = false)
        {
            _textrure_repeat = repeat;
            _texture_total_columns = cols;
            _textura = content.Load<Texture2D>(assetName);
            _texture_region = new Rectangle(0, 0, _textura.Width / cols, _textura.Height / rows);
        }

        public void Animacao(ref GameTime gameTime, int row)
        {
            accumulate_time += gameTime.ElapsedGameTime;
            if (accumulate_time >= TimeSpan.FromMilliseconds(100)) {
                accumulate_time = TimeSpan.Zero;
                _texture_current_column++;
                if (_texture_current_column == _texture_total_columns)
                    _texture_current_column = 0;
            }
            _texture_region.X = _texture_current_column * _texture_region.Width;
            _texture_region.Y = row * _texture_region.Height;
        }

        protected void Draw(ref SpriteBatch spriteBatch, Rectangle body)
        {

            // body
            Texture2D _blankTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            _blankTexture.SetData(new[] { Color.Red });
            spriteBatch.Draw(_blankTexture, new Vector2(body.X, body.Y), body, Color.White);

            // se nao fo reptir, scala dee se adequear ao body;
            Vector2 scale = new Vector2(body.Width / (float)_texture_region.Width, body.Height / (float)_texture_region.Height);
            if (_textrure_repeat)
            {
                // Escala 1 para 1
                scale = new Vector2(1, 1);
                _texture_region.Width = body.Width;
                _texture_region.Height = body.Height;
            }

            spriteBatch.Draw(
                _textura,
                new Vector2(body.X, body.Y),
                _texture_region,
                Color.White,
                0,
                Vector2.Zero,
                scale,
                SpriteEffects.None, 0);
        }

    }

    public class BaseObject : Sprite
    {
        protected Vector2 _velocity = new Vector2(0f);
        protected Rectangle _body = Rectangle.Empty;

        public Vector2 Position {
            get {
                return new Vector2(_body.X, _body.Y);
            }
        }

        public Rectangle Body
        {
            get
            {
                return _body;
            }
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            Draw(ref spriteBatch, _body);
        }

        public BaseObject(Rectangle rect, Vector2 velocity)
        {
            _body = rect;
            _velocity = velocity;
        }
    }
}

