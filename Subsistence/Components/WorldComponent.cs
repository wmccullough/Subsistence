using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Subsistence.GameObjects;
using Subsistence.Graphics;

namespace Subsistence.Components
{
    public class WorldComponent : DrawableGameComponent
    {
        public WorldComponent(Game game) : base(game)
        {
            GameObjects = new List<GameObject>();


        }
        public List<GameObject> GameObjects { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public Camera Camera { get; set; }

        private Point PreviousMousePosition;

        public override void Initialize()
        {
            SpriteBatch = new SpriteBatch(Game.GraphicsDevice);

            TiledSprite terrainSprite = new TiledSprite(new Point(3, 3), Game.Content.Load<Texture2D>(@"textures\mud_placeholder"), SpriteBatch);
            Sprite bushSprite = new Sprite(Game.Content.Load<Texture2D>(@"textures\bush_placeholder"), SpriteBatch);
            Sprite treeSprite = new Sprite(Game.Content.Load<Texture2D>(@"textures\tree_placeholder"), SpriteBatch);
            Sprite cabinSprite = new Sprite(Game.Content.Load<Texture2D>(@"textures\cabin_placeholder"), SpriteBatch);
            Sprite floorSprite = new TiledSprite(new Point(3, 2), Game.Content.Load<Texture2D>(@"textures\floor_placeholder"), SpriteBatch);

            GameObject terrain =
                GameObject
                    .Create<TerrainObject>()
                    .WithId("terrain")
                    .AtPosition(new Vector3(0, 0, 1))
                    .WithSprite(terrainSprite);

            AddGameObject(terrain);

            GameObject bush =
                GameObject.Create<TerrainObject>()
                .WithId("bush")
                .AtPosition(new Vector3(20, 20, 2))
                .WithSprite(bushSprite);

            AddGameObject(bush);

            GameObject tree =
                GameObject.Create<TerrainObject>()
                .WithId("tree")
                .AtPosition(new Vector3(300, 150, 2))
                .WithSprite(treeSprite);

            AddGameObject(tree);
            
            GameObject cabin =
                GameObject.Create<TerrainObject>()
                .WithId("cabin")
                .AtPosition(new Vector3(375, 110, 2))
                .WithSprite(cabinSprite);

            AddGameObject(cabin);

            //GameObject floorTerrain =
            //    GameObject.Create<TerrainObject>()
            //    .WithId("cabin")
            //    .AtPosition(new Vector3(300, 300, 2))
            //    .WithSprite(floorSprite);

            //AddGameObject(floorTerrain);

            Camera = new Camera(new Vector2(0, 0));

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            GameObjects = GameObjects.OrderBy(g => g.Position.Y).ToList();

            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                Point delta = mouse.Position - PreviousMousePosition;

                Camera.Pos -= new Vector2(delta.X, delta.Y);
            }

            foreach (GameObject gameObject in GameObjects) {
                gameObject.Update(gameTime);
            }

            PreviousMousePosition = mouse.Position;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, 
                DepthStencilState.Default, RasterizerState.CullNone, null, Camera.GetMatrix(Game.GraphicsDevice));

            foreach (GameObject gameObject in GameObjects) {
                gameObject.Draw(gameTime);
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        public WorldComponent AddGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);

            return this;
        }
    }
}
