using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Subsistence.Graphics;

namespace Subsistence.GameObjects
{
    public abstract class GameObject
    {
        protected GameObject()
        {
        }

        protected GameObject(string id, Vector3 position)
            : this(id, position, null)
        {
            
        }

        protected GameObject(string id, Vector3 position, Sprite sprite)
        {
            Id = id;
            Position = position;
            Sprite = sprite;
            Sprite.SetOwner(this);
        }

        public string Id { get; set; }
        public Vector3 Position { get; set; }
        public Sprite Sprite { get; set; }

        public static GameObject Create<T>() where T : GameObject
        {
            return Activator.CreateInstance<T>();
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Sprite != null)
            {
                Sprite.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (Sprite != null)
            {
                Sprite.Draw(gameTime);
            }
        }

        public void Move(Vector3 amount)
        {
            Position += amount;
        }

        public GameObject WithId(string id)
        {
            Id = id;
            return this;
        }

        public GameObject WithSprite(Sprite sprite)
        {
            Sprite = sprite;
            Sprite.SetOwner(this);
            return this;
        }

        public GameObject AtPosition(Vector3 position)
        {
            Position = position;
            return this;
        }
    }
}
