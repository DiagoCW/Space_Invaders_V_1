using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Space_Invaders_V_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        KeyboardState keyboardState, previousKeyboardState;

        int windowHeight;

        int score;
        const int scoreEnemyKill = 50; // Points to gain from killing enemy

        Player player;
        
        List<Enemy> enemies;

        List<Bullet> bullets;
        Texture2D bulletTex;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Size of client
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 1000;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            int windowWidth = graphics.PreferredBackBufferWidth;
            int windowHeight = graphics.PreferredBackBufferHeight;

            //All texture loads 
            Texture2D playerTex = Content.Load<Texture2D>("ship1");
            Texture2D enemyTex = Content.Load<Texture2D>("astroid");
            bulletTex = Content.Load<Texture2D>("ProjectileA");

            // Player setup
            Vector2 playerPos = new Vector2((graphics.PreferredBackBufferWidth - playerTex.Width) / 2, graphics.PreferredBackBufferHeight - playerTex.Height);
            player = new Player(playerTex, playerPos, 5f, windowWidth);

            // Enemy list and formation

            enemies = new List<Enemy>();
            
            const int enemySpacing_X = 100;
            const int enemySpacing_Y = 100;
            const int enemyRows = 3;
            const int enemyColumn = 6;

            for (int row = 0; row < enemyRows; row++) 
            {
                for (int column = 0; column < enemyColumn; column++) 
                {
                    int x = column * enemySpacing_X;
                    int y = row * enemySpacing_Y; 
                    
                    Color color = Color.White;

                    if (row == 0) color = Color.Red;
                    else if (row == 1) color = Color.Yellow;

                    Vector2 enemyPos = new Vector2(x, y);

                    Enemy e = new Enemy(enemyTex, enemyPos, color);
                    enemies.Add(e);
                }
            }
                
            bullets = new List<Bullet>();

        }

        protected override void Update(GameTime gameTime)
        {
            // Exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboardState = Keyboard.GetState();
            
            // Player update
            player.Update();

            // Update enemies
            foreach (var e in enemies) e.Update();
             
            foreach (var e in enemies)
            {
                if (e.enemyRect.Intersects(player.playerRect) || e.enemyPos.Y > player.playerPos.Y) Exit();
            }

            // Shooting bullets
            if (keyboardState.IsKeyDown(Keys.Space) && previousKeyboardState.IsKeyUp(Keys.Space))
            {
                Vector2 bulletPos = new Vector2(player.playerPos.X + (player.playerTex.Width / 2) - (bulletTex.Width / 2), player.playerPos.Y);
                Bullet b = new Bullet(bulletTex, bulletPos);
                bullets.Add(b);
            }
            foreach (var b in bullets) b.Update();

            // Killing enemy with bullets
            foreach (var b in bullets) 
            {
                foreach (var e in enemies) 
                {
                    if (b.bulletRect.Intersects(e.enemyRect))
                    {
                        e.enemyAlive = false;
                        b.isVisible = false;
                        score += scoreEnemyKill;
                    }
                }
            }
            
            enemies.RemoveAll(e => !e.enemyAlive); 
            bullets.RemoveAll(b => !b.isVisible || b.IsOffScreen(windowHeight));
            
            previousKeyboardState = keyboardState;

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
            
            // Draw bullets
            foreach (var b in bullets) b.Draw(spriteBatch);

            spriteBatch.End();

            Window.Title = "Space Invaders V.1. Score: " + score + ".";

            base.Draw(gameTime);
        }
    }
}
