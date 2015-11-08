using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Subsistence.GameObjects;

namespace Subsistence.Graphics
{
    public class TiledSprite : Sprite
    {
        
        public TiledSprite(Point span, Texture2D texture, SpriteBatch spriteBatch)
            : base(texture, spriteBatch)
        {
            Span = span;
        }

        public TiledSprite(Point span, GameObject gameObject, Texture2D texture, SpriteBatch spriteBatch)
            : base(gameObject, texture, spriteBatch)
        {
            Span = span;
        }

        public Point Span { get; set; }

        public override void Draw(GameTime gameTime)
        {
            if (GameObject == null) {
                return;
            }

            foreach (int y in Enumerable.Range(0, Span.Y))
            {
                foreach (int x in Enumerable.Range(0, Span.X))
                {
                    SpriteBatch.Draw(Texture, new Vector2(GameObject.Position.X + (x * Texture.Width), GameObject.Position.Y + (y * Texture.Height)), Color.White);
                }
            }
        }
    }
}
