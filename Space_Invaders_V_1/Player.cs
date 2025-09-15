using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.isAlive = true;

            playerRect = new Rectangle((int)playerPos.X, (int)playerPos.Y, playerTex.Width, playerTex.Height);

        }

        public void Update()
        {
        KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Left)) playerPos.X -= playerSpeed;
            if (keyState.IsKeyDown(Keys.Right)) playerPos.X += playerSpeed;

            //if (playerPos.X <= 0) playerPos.X = 0;
            //if (playerPos.X >= graphics.PreferredBackBufferWidth - playerTex.Width) playerPos.X = graphics.PreferredBackBufferWidth - playerTex.Width;
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
