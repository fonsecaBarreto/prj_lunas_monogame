using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_lebron.src.classes;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;


namespace Project_lebron
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Camera Camera;
        Character _personagem;
        Scenery ground;
        Scenery wall;

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

            _personagem = new Character(new Rectangle(300 - 48, 400 - 62, 96, 124));
            ground = new Scenery(new Rectangle(0, 0, 600, 600));
            wall = new Scenery(new Rectangle(-64, -64, 728, 64));
;
            _personagem.LoadContent(Content, "spritesv3", 4, 4);
            ground.LoadContent(Content, "grass", 1, 1, true);
            wall.LoadContent(Content, "bedrock", 1, 1, true);

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

            GraphicsDevice.Clear(Color.FloralWhite);

            // Rendereização de cenario

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap, null,null,null, Camera.Transform);
            ground.Draw(ref _spriteBatch);
            wall.Draw(ref _spriteBatch);
            _spriteBatch.End();

            // Render os characters

            _spriteBatch.Begin(transformMatrix: Camera.Transform);
            _personagem.Draw(ref _spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}