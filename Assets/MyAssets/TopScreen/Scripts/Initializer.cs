using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.TopScreen
{
    public class Initializer : MonoBehaviour
    {
        public void Execute()
        {
            ScreenScroller.Instance.Initialize();
        }
    }
}
