using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SpriteSheetBasics
{
    public abstract class MultiRowSprite
    {
        public Vector2 Position { get; set; }
        public Int32 SpriteWidth { get { return spriteWidth; } }
        public Int32 SpriteHeight { get { return spriteHeight; } }

        protected Int32 numberOfHorizontalFrames;
        protected Int32 numberOfVerticalFrames;
        protected Int32 spriteWidth;
        protected Int32 spriteHeight;
        protected Single interval;

        private Texture2D sprite;
        private SpriteBatch spriteBatch;
        private Single timer = 0f;        
        private Int32 currentHorizontalFrame = 1; 
        private Int32 currentVerticalFrame = 1;
        private Rectangle sourceRect;

        public MultiRowSprite(Texture2D sprite, SpriteBatch spriteBatch) : this(sprite, spriteBatch, Vector2.Zero) { }

        public MultiRowSprite(Texture2D sprite, SpriteBatch spriteBatch, Vector2 position)
        {
            this.sprite = sprite;
            this.spriteBatch = spriteBatch;
            this.Position = position;
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
        }

        public void Draw()
        {
            spriteBatch.Draw(sprite, new Vector2(Position.X, Position.Y), sourceRect, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
        }
    }
}
