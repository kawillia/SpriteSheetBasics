using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpriteSheetBasics
{
    public class WalkSequenceSprite : MultiRowSprite
    {
        public WalkSequenceSprite(Game game, ContentManager content, SpriteBatch spriteBatch)
            : base(game, content.Load<Texture2D>("walksequence"), spriteBatch)
        {
            numberOfHorizontalFrames = 6;
            numberOfVerticalFrames = 5;
            spriteWidth = 240;
            spriteHeight = 296;
            interval = 50f;
        }
    }
}
