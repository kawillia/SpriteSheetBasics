using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SpriteSheetBasics
{
    public class LoadingSprite : SingleRowSprite
    {
        public LoadingSprite(ContentManager content, SpriteBatch spriteBatch)
            : base(content.Load<Texture2D>("loading"), spriteBatch)
        {
            numberOfFrames = 10;
            spriteWidth = 72;
            spriteHeight = 72;
            interval = 100f;
        }
    }
}
