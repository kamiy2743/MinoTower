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
            foreach (var go in GetAllGameObjects.InActiveScene())
            {
                var staticStarts = go.GetComponents<IStaticStart>();
                foreach (var item in staticStarts)
                {
                    item.StaticStart();
                }
            }
        }
    }
}
