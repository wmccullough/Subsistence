using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Subsistence.Graphics;

namespace Subsistence.GameObjects
{
    public abstract class LivingGameObject : GameObject
    {
        public LivingGameObject() { }

        public LivingGameObject(string id, Vector3 position, Sprite sprite)
            : base(id, position, sprite)
        {
            
        }

        public float CurrentLife { get; set; }
        public float MaximumLife { get; set; }
        public bool IsAlive => CurrentLife > 0;

        public event EventHandler BeginDamaged = delegate { }; 
        public event EventHandler EndDamaged = delegate { };
        public event EventHandler BeginDeath = delegate { };
        public event EventHandler EndDeath = delegate { };

        public void CauseDamage(float amount)
        {
            if (CurrentLife - amount > 0.0f)
            {
                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                BeginDamaged(this, cancelEventArgs);

                if (!cancelEventArgs.Cancel)
                {
                    EndDamaged(this, null);
                }
            }
            else
            {
                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                BeginDeath(this, cancelEventArgs);

                if (!cancelEventArgs.Cancel)
                {
                    EndDeath(this, null);
                }
            }
        }

        public void Kill()
        {
            CurrentLife = 0;

            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            BeginDeath(this, cancelEventArgs);

            if (!cancelEventArgs.Cancel) {
                EndDeath(this, null);
            }
        }
    }
}
