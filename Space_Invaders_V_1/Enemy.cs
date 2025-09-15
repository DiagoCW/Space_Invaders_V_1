using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_V_1
{
    internal class Enemy
    {
        public Texture2D enemyTex;
        public Vector2 enemyPos;
        public Rectangle enemyRect;
        public bool enemyAlive;
        public Color color;
        public Vector2 enemySpeed;

        public Enemy(Texture2D enemyTex, Vector2 enemyPos, Color color) 
        {
            this.enemyTex = enemyTex;
            this.enemyPos = enemyPos;
            this.enemySpeed = new Vector2(0, 2);
            this.color = color;

            enemyRect = new Rectangle ((int)enemyPos.X, (int)enemyPos.Y, enemyTex.Width, enemyTex.Height);
        }

        public void Update() 
        {
            enemyPos += enemySpeed;

            enemyRect.Location = enemyPos.ToPoint();

        }

        public void Draw(SpriteBatch spritebatch) 
        {
            spritebatch.Draw(enemyTex, enemyPos, color);
        }
    }
}
