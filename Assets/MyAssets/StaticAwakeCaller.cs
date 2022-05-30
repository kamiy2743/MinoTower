using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class StaticAwakeCaller : MonoBehaviour
    {
        void Awake()
        {
            var staticAwakes = transform.root.GetComponentsInChildren<IStaticAwake>();
            foreach (var item in staticAwakes)
            {
                item.StaticAwake();
            }
        }
    }
}
