using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Sokoban2024
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
        private int nrLinhas = 0;
        private int nrColunas = 0;
        private char[,] level;
        private Texture2D player, dot, box, wall;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            Loadlevel("level1.txt");

            base.Initialize();
           
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("File"); //Use the name of sprite font file (´File´)



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //_spriteBatch.DrawString(font, "O texto que quiser", new Vector2(0, 0), Color.Black);
            //_spriteBatch.DrawString(font, $"Numero de Linhas = {nrLinhas} -- Numero de colunas = {nrColunas}", new Vector2(300, 100), Color.Black);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        void Loadlevel(string levelFile)
        {
            string[] linhas = File.ReadAllLines($"Content/{levelFile}");
            nrLinhas = linhas.Length;
            nrColunas = linhas[0].Length;

            level = new char[nrLinhas, nrColunas];

            for (int x = 0; x < nrColunas; x++)
            {
                for (int y = 0; y < nrLinhas; y++)
                {
                    level[x,y] = linhas[x][y];
                }
            }
        }
    }
}