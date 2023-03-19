using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_lebron.src.classes;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using static System.Net.Mime.MediaTypeNames;

namespace Project_lebron
{
    public class Game1 : Game
    {
    
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Character _personagem = new Character(new Rectangle(0, 0, 96, 124));
        Scenery ground = new Scenery(new Rectangle(0, 0, 1024, 1024));

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            // graphics
            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _personagem.LoadContent(Content, "spritesfinal", 4, 4);
            ground.LoadContent(Content, "grass", 1, 1, true);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _personagem.Mover(ref gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            int screen_mid_width = GraphicsDevice.Adapter.CurrentDisplayMode.Width / 2;
            int screen_mid_height = GraphicsDevice.Adapter.CurrentDisplayMode.Height / 2;

            Vector2 position = _personagem.getPosition();

            GraphicsDevice.Clear(Color.Aqua);

            // Rendereização de cenario
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap);


            ground.Draw(ref _spriteBatch, screen_mid_width - (int) position.X, screen_mid_height - (int) position.Y);
            // tree.Draw(ref _spriteBatch);

            _spriteBatch.End();


            // Rederização do usuario

            _spriteBatch.Begin();

 
            _personagem.Draw(ref _spriteBatch, screen_mid_width, screen_mid_height);


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}