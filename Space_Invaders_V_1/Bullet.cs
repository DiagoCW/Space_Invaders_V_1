using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Space_Invaders_V_1
{
    internal class Bullet
    {
        public Texture2D bulletTex;
        public Vector2 bulletPos;
        public float bulletSpeed;
        const float _bulletSpeed = 10f;
        public bool isVisible;
        public Rectangle bulletRect;
        
        public Bullet(Texture2D bulletTex, Vector2 bulletPos) 
        {
            this.bulletTex = bulletTex;
            this.bulletPos = bulletPos;
            bulletSpeed = _bulletSpeed;

            isVisible = true;

            bulletRect = new Rectangle((int)bulletPos.X, (int)bulletPos.Y, bulletTex.Width, bulletTex.Height);
        }

        public bool IsOffScreen(int windowHeight)
        {
            return bulletPos.Y < 0;
        }

        public void Update() 
        {
            bulletPos.Y -= bulletSpeed;

            bulletRect.Location = bulletPos.ToPoint();

            if (bulletPos.Y < 0) isVisible = false;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (isVisible) spritebatch.Draw(bulletTex, bulletPos, Color.Red);
        }

    }
}
