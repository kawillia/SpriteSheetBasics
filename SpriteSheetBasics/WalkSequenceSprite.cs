using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpriteSheetBasics
{
    public class WalkSequenceSprite : MultiRowSpriteSheet
    {
        public WalkSequenceSprite(ContentManager content, SpriteBatch spriteBatch, Vector2 position)
            : base(content.Load<Texture2D>("walksequence"), spriteBatch, position)
        {
            numberOfHorizontalFrames = 6;
            numberOfVerticalFrames = 5;
            spriteWidth = 240;
            spriteHeight = 296;
            interval = 50f;
        }
    }
}
