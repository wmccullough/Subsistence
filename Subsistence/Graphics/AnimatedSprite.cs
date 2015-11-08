using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Subsistence.Graphics
{
    public class AnimatedSprite : Sprite
    {
        public AnimatedSprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle[] frames, double interval)
            : base(texture, spriteBatch)
        {
            Frames = frames;
            Interval = interval;
        }

        private int _frameIndex;
        private double _tick;
        public double Interval { get; set; }
        public Rectangle[] Frames { get; set; }

        public Rectangle CurrentFrame => Frames[_frameIndex];

        public override void Update(GameTime gameTime)
        {
            if (_tick >= Interval)
            {
                _frameIndex++;
                _tick = 0d;

                if (_frameIndex > Frames.Length)
                {
                    _frameIndex = 0;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (GameObject == null) {
                return;
            }

            SpriteBatch.Draw(Texture, new Vector2(GameObject.Position.X, GameObject.Position.Y), CurrentFrame, Color.White);
        }
    }
}
