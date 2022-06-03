using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MT.Extension;

namespace MT
{
    public class StaticAwakeCaller
    {
        public void Call()
        {
            var scene = SceneManager.GetActiveScene();
            foreach (var root in scene.GetRootGameObjects())
            {
                CallStaticAwake(root);

                var children = root.transform.GetChildrenRecursive();
                foreach (var child in children)
                {
                    CallStaticAwake(child.gameObject);
                }
            }
        }

        private void CallStaticAwake(GameObject target)
        {
            var staticAwakes = target.GetComponents<IStaticAwake>();
            foreach (var item in staticAwakes)
            {
                item.StaticAwake();
            }
        }
    }
}
