using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.MatchMakingScreen
{
    public class MatchMakingScreen : MonoBehaviour, IScreen
    {
        public ScreenType Type { get; private set; } = ScreenType.MatchMaking;

        public void Open()
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
        }

        public void Close()
        {
            if (!gameObject.activeSelf) return;

            gameObject.SetActive(false);
        }
    }
}
