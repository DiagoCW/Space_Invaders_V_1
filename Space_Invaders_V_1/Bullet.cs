using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_V_1
{
    internal class Bullet
    {
        public Texture2D bulletTex;
        public Vector2 bulletPos;
        public float bulletSpeed;
        public bool isVisible;
        public Rectangle bulletRect;

        

        public Bullet(Texture2D bulletTex, Vector2 bulletPos, float bulletSpeed) 
        {
            this.bulletTex = bulletTex;
            this.bulletPos = bulletPos;
            this.bulletSpeed = bulletSpeed;
        }

        //public void Update();



        //public void Draw(SpriteBatch spritebatch;)

    }
}
