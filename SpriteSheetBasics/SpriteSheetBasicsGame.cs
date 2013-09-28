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
        private LoadingSprite loadingSprite;
        private WalkSequenceSprite walkSequenceSprite;

        public SpriteSheetBasicsGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            loadingSprite = new LoadingSprite(Content, spriteBatch);
            loadingSprite.Position = new Vector2(
                graphics.PreferredBackBufferWidth - loadingSprite.SpriteWidth - 10,
                graphics.PreferredBackBufferHeight - loadingSprite.SpriteHeight - 10);

            walkSequenceSprite = new WalkSequenceSprite(Content, spriteBatch);
            walkSequenceSprite.Position = new Vector2(
                (graphics.PreferredBackBufferWidth / 2) - (walkSequenceSprite.SpriteWidth / 2),
                (graphics.PreferredBackBufferHeight / 2) - (walkSequenceSprite.SpriteHeight / 2));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            loadingSprite.Update(gameTime);
            walkSequenceSprite.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            loadingSprite.Draw();
            walkSequenceSprite.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
