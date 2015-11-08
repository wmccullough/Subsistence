using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Subsistence.Graphics;

namespace Subsistence.GameObjects
{
    public class TerrainObject : GameObject
    {
        public TerrainObject() { }
        public TerrainObject(string id, Vector3 position)
            : base(id, position)
        {
            
        }

        public TerrainObject(string id, Vector3 position, Sprite sprite)
            : base(id, position, sprite)
        {
            
        }
    }
}
