using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Subsistence.GameObjects;

namespace Subsistence.Graphics
{
    public class Sprite
    {
        public Sprite() { }

        public Sprite(Texture2D texture, SpriteBatch spriteBatch)
            : this(null, texture, spriteBatch)
        {
            
        }

        public Sprite(GameObject gameObject, Texture2D texture, SpriteBatch spriteBatch)
        {
            GameObject = gameObject;
            Texture = texture;
            SpriteBatch = spriteBatch;
        }

        public GameObject GameObject { get; set; }

        public SpriteBatch SpriteBatch { get; set; }
        public Texture2D Texture { get; set; }

        public static Sprite Create<T>() where T : Sprite
        {
            return Activator.CreateInstance<T>();
        }


        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (GameObject == null)
            {
                return;
            }

            SpriteBatch.Draw(Texture, new Vector2(GameObject.Position.X, GameObject.Position.Y), Color.White);
        }

        public void SetOwner(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        public Sprite WithTexture(Texture2D texture)
        {
            Texture = texture;
            return this;
        }

        public Sprite WithSpriteBatch(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
            return this;
        }

        public Sprite WithOwner(GameObject gameObject)
        {
            GameObject = gameObject;
            return this;
        }
    }
}
