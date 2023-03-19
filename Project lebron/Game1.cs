using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_lebron.src.classes;
using System.Numerics;


namespace Project_lebron
{
    public class Game1 : Game
    {

        private Camera Camera;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Character _personagem;
        Scenery ground;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // graphics
            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();
            // base
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Camera = new Camera(GraphicsDevice.Adapter.CurrentDisplayMode.Width, GraphicsDevice.Adapter.CurrentDisplayMode.Height);

            _personagem = new Character(new Rectangle(512 - 48, 400 - 62, 96, 124));
            ground = new Scenery(new Rectangle(0, 0, 1024, 800));

            _personagem.LoadContent(Content, "spritesfinal", 4, 4);
            ground.LoadContent(Content, "grass", 1, 1, true);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _personagem.Mover(ref gameTime);

            Camera.Follow(_personagem);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            // Rendereização de cenario
            //_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap);

            GraphicsDevice.Clear(Color.AntiqueWhite);
            _spriteBatch.Begin(transformMatrix: Camera.Transform);

            ground.Draw(ref _spriteBatch);
            _personagem.Draw(ref _spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}