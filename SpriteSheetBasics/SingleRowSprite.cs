using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpriteSheetBasics
{
    public abstract class SingleRowSprite : DrawableGameComponent
    {
        public Vector2 Position { get; set; }
        public Int32 SpriteWidth { get { return spriteWidth; } }
        public Int32 SpriteHeight { get { return spriteHeight; } }

        protected Int32 numberOfFrames;
        protected Int32 spriteWidth;
        protected Int32 spriteHeight;
        protected Single interval;

        private Texture2D sprite;
        private SpriteBatch spriteBatch;
        private Single timer = 0f;        
        private Int32 currentFrame = 1;        
        private Rectangle sourceRect;

        public SingleRowSprite(Game game, Texture2D sprite, SpriteBatch spriteBatch) : this(game, sprite, spriteBatch, Vector2.Zero) { }

        public SingleRowSprite(Game game, Texture2D sprite, SpriteBatch spriteBatch, Vector2 position) : base(game)
        {
            this.sprite = sprite;
            this.spriteBatch = spriteBatch;
            this.Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            timer += (Single)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;
                timer = 0f;
            }

            if (currentFrame == numberOfFrames)
                currentFrame = 0;

            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Draw(sprite, new Vector2(Position.X, Position.Y), sourceRect, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
        }
    }
}
