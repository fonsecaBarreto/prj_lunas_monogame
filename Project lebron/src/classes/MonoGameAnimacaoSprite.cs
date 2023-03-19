using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using static System.Formats.Asn1.AsnWriter;

namespace Project_lebron.src.classes
{
    public abstract class AnimacaoSprite
    {

        public bool Ativado = false;

        public Texture2D _textura;
        private int _frameLargura;
        private int _frameAltura;
        public Rectangle _regiaoDaTextura = Rectangle.Empty;
        private int _frameAtualDaColuna;
        private TimeSpan _acumulaTempo = TimeSpan.Zero;
        private int TotalColunasNaSprite = 0;
        private bool _repeatTexture = false;

        public void LoadContent(ContentManager content, string assetName, int rows=1, int cols = 1, bool repeat = false)
        {

            _repeatTexture = repeat;
            TotalColunasNaSprite = cols;
            _textura = content.Load<Texture2D>(assetName);

            _frameLargura = _textura.Width / cols;
            _frameAltura = _textura.Height / rows;

            _regiaoDaTextura = new Rectangle(0, 0, _frameLargura, _frameAltura);
        }

        public void Animacao(ref GameTime gameTime, int row)
        {
            if (!Ativado)
                return;

            _acumulaTempo += gameTime.ElapsedGameTime;

            if (_acumulaTempo >= TimeSpan.FromMilliseconds(100))
            {
                _frameAtualDaColuna++;

                if (_frameAtualDaColuna == TotalColunasNaSprite)
                    _frameAtualDaColuna = 0;

                _acumulaTempo = TimeSpan.Zero;
            }

            _regiaoDaTextura.X = _frameAtualDaColuna * _frameLargura;
            _regiaoDaTextura.Y = row * _frameAltura;
        }

        protected void Draw(ref SpriteBatch spriteBatch, Rectangle body)
        {

            // borders
            Texture2D _blankTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            _blankTexture.SetData(new[] { Color.Red });
            spriteBatch.Draw(_blankTexture, new Vector2(body.X, body.Y), body, Color.White);
            // textures

            // se nao fo reptir, scala dee se adequear ao body;
            Vector2 scale = new Vector2( body.Width / (float)_regiaoDaTextura.Width, body.Height / (float)_regiaoDaTextura.Height);
            if (_repeatTexture) {
                // Escala 1 para 1
                scale = new Vector2(1, 1);
                _regiaoDaTextura.Width = body.Width;
                _regiaoDaTextura.Height = body.Height;
            }

            spriteBatch.Draw(
                _textura,
                new Vector2(body.X, body.Y), 
                _regiaoDaTextura, 
                Color.White, 
                0, 
                Vector2.Zero, 
                scale, 
                SpriteEffects.None, 0);
        }

    }
 
}
