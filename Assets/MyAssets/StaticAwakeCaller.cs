using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MT
{
    public class StaticAwakeCaller : MonoBehaviour
    {
        void Awake()
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
