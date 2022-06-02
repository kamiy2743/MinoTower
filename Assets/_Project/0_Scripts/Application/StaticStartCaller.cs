using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MT
{
    public class StaticStartCaller
    {
        public void Call()
        {
            var scene = SceneManager.GetActiveScene();
            foreach (var root in scene.GetRootGameObjects())
            {
                var staticStarts = root.GetComponentsInChildren<IStaticStart>();
                foreach (var item in staticStarts)
                {
                    item.StaticStart();
                }
            }
        }
    }
}
