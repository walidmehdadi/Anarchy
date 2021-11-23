using Anarchy.Animation;
using Anarchy.Input;
using Anarchy.Interfaces;
using Anarchy.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anarchy
{
    public class Hero:IGameObject,IMovable
    {
        private Texture2D idleTexture;
        private Texture2D runningTexture;
        private Animate animation;
        private MovementManager movementManager;
        private int numberOfWidthSprites;
        private int numberOfHeightSprites;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }

        public Hero(Texture2D idleTexture, Texture2D runningTexture, IInputReader inputReader)
        {
            this.idleTexture = idleTexture;
            this.runningTexture = runningTexture;
            this.InputReader = inputReader;
            movementManager = new MovementManager();
            animation = new Animate();
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Right))
            {
                animation.GetFramesFromTextureProperties(runningTexture.Width, runningTexture.Height, 6, 1);
            }
            else
            {
                animation.GetFramesFromTextureProperties(idleTexture.Width, idleTexture.Height, 8, 1);
            }
            Position = new Vector2(0, 330);
            Speed = new Vector2(4,4);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Right))
            {
                spriteBatch.Draw(runningTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(idleTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
            }
            
        }

        private void Move()
        {
            movementManager.Move(this);
            KeyboardState state = Keyboard.GetState();
        }

        public void ChangeInput(IInputReader inputReader)
        {
            this.InputReader = inputReader;
        }
    }
}
