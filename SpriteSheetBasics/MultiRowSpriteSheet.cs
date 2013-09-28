using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SpriteSheetBasics
{
    public abstract class MultiRowSpriteSheet
    {
        protected Int32 numberOfHorizontalFrames;
        protected Int32 numberOfVerticalFrames;
        protected Int32 spriteWidth;
        protected Int32 spriteHeight;
        protected Single interval;

        private Texture2D sprite;
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private Single timer = 0f;        
        private Int32 currentHorizontalFrame = 1; 
        private Int32 currentVerticalFrame = 1;
        private Rectangle sourceRect;
        private Vector2 origin;

        public MultiRowSpriteSheet(Texture2D sprite, SpriteBatch spriteBatch, Vector2 position)
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
                currentHorizontalFrame++;
                timer = 0f;
            }

            if (currentHorizontalFrame == numberOfHorizontalFrames)
            {
                currentHorizontalFrame = 0;
                currentVerticalFrame++;
            }

            if (currentVerticalFrame == numberOfVerticalFrames)
            {
                currentHorizontalFrame = 0;
                currentVerticalFrame = 0;
            }

            sourceRect = new Rectangle(currentHorizontalFrame * spriteWidth, currentVerticalFrame * spriteHeight, spriteWidth, spriteHeight);
            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
        }

        public void Draw()
        {
            spriteBatch.Draw(sprite, new Vector2(position.X, position.Y), sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
