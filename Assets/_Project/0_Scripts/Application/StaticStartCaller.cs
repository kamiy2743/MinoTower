using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MT.Extension;

namespace MT
{
    public class StaticStartCaller
    {
        public void Call()
        {
            var scene = SceneManager.GetActiveScene();
            foreach (var root in scene.GetRootGameObjects())
            {
                CallStaticStart(root);

                var children = root.transform.GetChildrenRecursive();
                foreach (var child in children)
                {
                    CallStaticStart(child.gameObject);
                }
            }
        }

        private void CallStaticStart(GameObject target)
        {
            var staticStarts = target.GetComponents<IStaticStart>();
            foreach (var item in staticStarts)
            {
                item.StaticStart();
            }
        }
    }
}
