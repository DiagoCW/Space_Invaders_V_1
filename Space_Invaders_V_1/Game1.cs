using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Space_Invaders_V_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        int score;

        Player player;
        //Texture2D playerTex;
        Rectangle playerRect;

        Enemy enemy;
        List<Enemy> enemies;
        List<Enemy> enemies2;
        List<Enemy> enemies3;
        Texture2D enemyTex;
        Rectangle enemyRect;

        Bullet bullet;
        Texture2D bulletTex;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 800;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            int windowWidth = Window.ClientBounds.Width;
            int windowHeight = Window.ClientBounds.Height;

            //All texture loads 
            Texture2D playerTex = Content.Load<Texture2D>("ship1");
            enemyTex = Content.Load<Texture2D>("astroid");

            // Player setup
            Vector2 playerPos = new Vector2((graphics.PreferredBackBufferWidth - playerTex.Width) / 2, graphics.PreferredBackBufferHeight - playerTex.Height);
            player = new Player(playerTex, playerPos, 5f, windowWidth);

            // Enemy row 1: Red
            enemies = new List<Enemy>();
            for (int i = 0; i < 6; i++)
            {
                int x = i * 100;
                int y = 10;
                Vector2 enemyPos = new Vector2 (x, y);
                Enemy e = new Enemy(enemyTex, enemyPos, Color.Red);
                enemies.Add(e);
            }

            // Enemy row 2: Yellow
            enemies2 = new List<Enemy>();
            for (int i = 0; i < 6; i++)
            {
                int x = i * 100;
                int y = 110;
                Vector2 enemyPos = new Vector2(x, y);
                Enemy e = new Enemy(enemyTex, enemyPos, Color.Yellow);
                enemies2.Add(e);
            }

            // Enemy row 3: Transparent
            enemies3 = new List<Enemy>();
            for (int i = 0; i < 6; i++)
            {
                int x = i * 100;
                int y = 210;
                Vector2 enemyPos = new Vector2(x, y);
                Enemy e = new Enemy(enemyTex, enemyPos, Color.White);
                enemies3.Add(e);
            }

        }

        protected override void Update(GameTime gameTime)
        {
            // Exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Player update
            player.Update();

            // Constrain player to screen
            //if (player.playerPos.X <= 0) player.playerPos.X = 0;
            //if (player.playerPos.X >= graphics.PreferredBackBufferWidth - player.playerTex.Width) player.playerPos.X = graphics.PreferredBackBufferWidth - player.playerTex.Width;

            // Update player rectangle
            //player.playerRect = new Rectangle((int)player.playerPos.X, (int)player.playerPos.Y, playerTex.Width, playerTex.Height);

            // Update enemies
            foreach (var enemy in enemies) enemy.Update();
            foreach (var enemy in enemies2) enemy.Update();
            foreach (var enemy in enemies3) enemy.Update();

            foreach (var e in enemies.Concat(enemies2).Concat(enemies3))
            {
                if (e.enemyRect.Intersects(player.playerRect)) Exit();
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Draw player
            player.Draw(spriteBatch);

            // Draw enemies
            foreach (var e in enemies) e.Draw(spriteBatch);
            foreach (var e in enemies2) e.Draw(spriteBatch);
            foreach (var e in enemies3) e.Draw(spriteBatch);

            spriteBatch.End();

            Window.Title = "Space Invaders V.1. Score: 0";

            base.Draw(gameTime);
        }
    }
}
