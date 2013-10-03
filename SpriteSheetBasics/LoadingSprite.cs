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
        public LoadingSprite(Game game, ContentManager content, SpriteBatch spriteBatch)
            : base(game, content.Load<Texture2D>("loading"), spriteBatch)
        {
            numberOfFrames = 10;
            spriteWidth = 36;
            spriteHeight = 36;
            interval = 100f;
        }
    }
}
