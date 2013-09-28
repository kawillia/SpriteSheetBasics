using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpriteSheetBasics
{
    public abstract class SingleRowSpriteSheet
    {
        protected Int32 numberOfFrames;
        protected Int32 spriteWidth;
        protected Int32 spriteHeight;
        protected Single interval;

        private Texture2D sprite;
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private Single timer = 0f;        
        private Int32 currentFrame = 1;        
        private Rectangle sourceRect;
        private Vector2 origin;

        public SingleRowSpriteSheet(Texture2D sprite, SpriteBatch spriteBatch, Vector2 position)
        {
            this.sprite = sprite;
            this.spriteBatch = spriteBatch;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            timer += (Single)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;
                timer = 0f;
            }

            if (currentFrame == numberOfFrames)
                currentFrame = 0;

            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
        }

        public void Draw()
        {
            spriteBatch.Draw(sprite, new Vector2(position.X, position.Y), sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
