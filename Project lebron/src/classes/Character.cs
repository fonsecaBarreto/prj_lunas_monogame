using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Reflection;
using System.Net.NetworkInformation;

namespace Project_lebron.src.classes
{

    public class Character : BaseObject
    {
        static int _players_count;
        private int _playerIndex;

        public Character(Rectangle rect) : base(rect, new Vector2(300f))
        {
            _playerIndex = Character._players_count;
            Character._players_count++;
        }

        public void Mover(ref GameTime gameTime)
        {
            double tempoDecorridoJogo = gameTime.ElapsedGameTime.TotalSeconds;
            var kstate = Keyboard.GetState();

            if (_playerIndex == 1 && kstate.IsKeyDown(Keys.Up) ||(_playerIndex == 0 && kstate.IsKeyDown(Keys.W)))
            {
                Animacao(ref gameTime, 3);
                _body.Y -= (int)(_velocity.Y * tempoDecorridoJogo);
            }

            if (_playerIndex == 1 && kstate.IsKeyDown(Keys.Down) || (_playerIndex == 0 && kstate.IsKeyDown(Keys.S)))
            {
                Animacao(ref gameTime, 0);
                _body.Y += (int)(_velocity.Y * tempoDecorridoJogo);
            }

            if (_playerIndex == 1 && kstate.IsKeyDown(Keys.Left) || (_playerIndex == 0 && kstate.IsKeyDown(Keys.A)))
            {
                Animacao(ref gameTime, 1);
                _body.X -= (int)(_velocity.X * tempoDecorridoJogo);
            }


            if (_playerIndex == 1 && kstate.IsKeyDown(Keys.Right) || (_playerIndex == 0 && kstate.IsKeyDown(Keys.D)))
            {
                Animacao(ref gameTime, 2);
                _body.X += (int)(_velocity.X * tempoDecorridoJogo);
            }

        }
    }

}