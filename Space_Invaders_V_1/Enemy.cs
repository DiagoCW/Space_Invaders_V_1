using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        const float _enemySpeed = 2;

        public Enemy(Texture2D enemyTex, Vector2 enemyPos, Color color) 
        {
            this.enemyTex = enemyTex;
            this.enemyPos = enemyPos;
            enemySpeed = new Vector2(0, _enemySpeed);
            this.color = color;
            enemyAlive = true;

            enemyRect = new Rectangle ((int)enemyPos.X, (int)enemyPos.Y, enemyTex.Width, enemyTex.Height);
        }

        public void Update() 
        {
            enemyPos += enemySpeed;

            enemyRect.Location = enemyPos.ToPoint();
        }

        public void Draw(SpriteBatch spritebatch) 
        {
            if (enemyAlive) spritebatch.Draw(enemyTex, enemyPos, color);
            
        }
    }
}
