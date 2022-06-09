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
            foreach (var go in GetAllGameObjects.InActiveScene())
            {
                var staticAwakes = go.GetComponents<IStaticAwake>();
                foreach (var item in staticAwakes)
                {
                    item.StaticAwake();
                }
            }
        }
    }
}
