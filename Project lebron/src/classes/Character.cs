using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Reflection;

namespace Project_lebron.src.classes
{

    public class Character : AnimacaoSprite
    {
        public Vector2 Velocidade = new Vector2(300f);
        public Rectangle body = Rectangle.Empty;
        private int _playerIndex;

        public Character(Rectangle rect, int index = 0)
        {
            _playerIndex = index;
            body = rect;
        }

        public Vector2 getPosition()
        {
            return new Vector2(body.X, body.Y);
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            Draw(ref spriteBatch, body);
        }

        public void Mover(ref GameTime gameTime)
        {
            string[] player1Dic = { "Up" };
            double tempoDecorridoJogo = gameTime.ElapsedGameTime.TotalSeconds;
            var kstate = Keyboard.GetState();

            Ativado = true;

            if (_playerIndex == 1 && kstate.IsKeyDown(Keys.Up) ||(_playerIndex == 0 && kstate.IsKeyDown(Keys.W)))
            {
                Animacao(ref gameTime, 1);
                body.Y -= (int)(Velocidade.Y * tempoDecorridoJogo);
            }

            if (_playerIndex == 1 && kstate.IsKeyDown(Keys.Down) || (_playerIndex == 0 && kstate.IsKeyDown(Keys.S)))
            {
                Animacao(ref gameTime, 0);
                body.Y += (int)(Velocidade.Y * tempoDecorridoJogo);
                //Ativado = true;
            }

            if (_playerIndex == 1 && kstate.IsKeyDown(Keys.Left) || (_playerIndex == 0 && kstate.IsKeyDown(Keys.A)))
            {
                Animacao(ref gameTime, 2);
                body.X -= (int)(Velocidade.X * tempoDecorridoJogo);
                //Ativado = true;
            }


            if (_playerIndex == 1 && kstate.IsKeyDown(Keys.Right) || (_playerIndex == 0 && kstate.IsKeyDown(Keys.D)))
            {
                Animacao(ref gameTime, 3);
                body.X += (int)(Velocidade.X * tempoDecorridoJogo);
                //Ativado = true;
            }

        }
    }

}