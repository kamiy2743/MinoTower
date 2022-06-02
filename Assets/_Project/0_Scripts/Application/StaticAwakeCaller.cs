using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MT.Application
{
    public class StaticAwakeCaller
    {
        public void Call()
        {
            var scene = SceneManager.GetActiveScene();
            foreach (var root in scene.GetRootGameObjects())
            {
                var staticAwakes = root.GetComponentsInChildren<IStaticAwake>();
                foreach (var item in staticAwakes)
                {
                    item.StaticAwake();
                }
            }
        }
    }
}
