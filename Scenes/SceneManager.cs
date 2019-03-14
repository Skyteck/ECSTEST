using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSTEST.Scenes
{
    public class SceneManager
    {
        private List<Scene> SceneList = new List<Scene>();
        public Scene _ActiveScene { get; private set; }
        public Scene _PreviousScene { get; private set; }
        public GameWindow _Window { get; }
        public GraphicsDevice GraphicsDevice { get; }
        public SceneManager(GameWindow window, GraphicsDevice graphicsDevice)
        {
            _Window = window;
            GraphicsDevice = graphicsDevice;
        }

        public Scene GetActiveScene()
        {
            foreach (Scene t in SceneList)
            {
                if (t._Active)
                {
                    return t;
                }
            }
            Console.WriteLine("No active scene!");
            return null;
        }

        public void AddScene(Scene s)
        {
            SceneList.Add(s);
        }

        public void ActivateScene(string SceneName)
        {
            int activeScenes = 0;
            foreach (Scene t in SceneList)
            {
                if (t._Name == SceneName)
                {
                    if (_ActiveScene != null)
                    {
                        _ActiveScene._Active = false;
                        _PreviousScene = _ActiveScene;
                        _PreviousScene.UnloadContent();
                    }
                    t._Active = true;
                    t.LoadContent();
                    _ActiveScene = t;
                    activeScenes++;
                    _Window.Title = "Armada Engine - " + _ActiveScene._Name;
                }
            }

            if (activeScenes > 1)
            {
                Console.WriteLine("Too many active scenes!");
            }
        }

        public void Update()
        {
            _ActiveScene.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle b)
        {
            _ActiveScene.Draw(sb, b);
        }
    }
}