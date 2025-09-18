using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Space_Invaders_V_1
{
    internal class Player
    {
        public Texture2D playerTex;
        public Vector2 playerPos;
        public float playerSpeed;
        public bool isAlive;
        public Rectangle playerRect;
        public int windowWidth;

        public Player(Texture2D playerTex, Vector2 playerPos, float playerSpeed, int windowWidth) 
        {
            this.playerTex = playerTex;
            this.playerPos = playerPos;
            this.playerSpeed = playerSpeed;
            this.windowWidth = windowWidth;

            isAlive = true;

            playerRect = new Rectangle((int)playerPos.X / 2, (int)playerPos.Y / 2, playerTex.Width / 2, playerTex.Height /2); // player hitbox. /2 to make hitbox less sensitive
        }

        public void Update()
        {
        KeyboardState keyState = Keyboard.GetState();
            // Left / right movement
            if (keyState.IsKeyDown(Keys.Left)) playerPos.X -= playerSpeed;
            if (keyState.IsKeyDown(Keys.Right)) playerPos.X += playerSpeed;

            // Prevent player from leaving screen width
            if (playerPos.X < 0) playerPos.X = 0;
            if (playerPos.X > windowWidth - playerTex.Width) playerPos.X = windowWidth - playerTex.Width;

            playerRect.Location = playerPos.ToPoint();
        }

        public void Draw(SpriteBatch spritebatch) 
        {
            spritebatch.Draw(playerTex, playerPos, Color.White);
        }
    }
}
