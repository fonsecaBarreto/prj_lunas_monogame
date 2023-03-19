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

        Character _personagem = new Character(new Vector2(30f, 20f));
        Character _player2 = new Character(new Vector2(100f, 20f), 1);
        // Character _npc = new Character(new Vector2(300f, 50f));
        // Scenery moon = new Scenery(new Rectangle(300, 50, 32, 32));

        Scenery ground = new Scenery(new Rectangle(32, 32, 1024, 1024));

        // Scenery tree = new Scenery(new Rectangle(300, 300, 96, 96));


        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
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
            _player2.LoadContent(Content, "boneca_lunav3", 4, 4);
            //_npc.LoadContent(Content, "spritesfinal", 4, 4);

            ground.LoadContent(Content, "grass", 1, 1, true);
            // tree.LoadContent(Content, "tree", 2, 2, false);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


           _personagem.Mover(ref gameTime);
            _player2.Mover(ref gameTime);
            //  tree.Mover(ref gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aqua);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap);


            ground.Draw(ref _spriteBatch);
            // tree.Draw(ref _spriteBatch);

            _spriteBatch.End();

            _spriteBatch.Begin();

            _personagem.Draw(ref _spriteBatch);
            _player2.Draw(ref _spriteBatch);
            //_npc.Draw(ref _spriteBatch);



            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}