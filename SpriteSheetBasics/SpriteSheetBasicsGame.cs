using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace SpriteSheetBasics
{
    public class SpriteSheetBasicsGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SingleRowSpriteSheet loadingSprite;
        private MultiRowSpriteSheet multiRowSpriteSheet;

        public SpriteSheetBasicsGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            loadingSprite = new LoadingSprite(Content, spriteBatch, new Vector2(700, 400));
            multiRowSpriteSheet = new WalkSequenceSprite(Content, spriteBatch, new Vector2(380, 200));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            loadingSprite.Update(gameTime);
            multiRowSpriteSheet.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            loadingSprite.Draw();
            multiRowSpriteSheet.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
