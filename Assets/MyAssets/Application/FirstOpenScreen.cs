using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens;

namespace MT.Application
{
    public class FirstOpenScreen : MonoBehaviour
    {
        [SerializeField] private GameObject[] _screenObjects;
        [SerializeField] private ScreenType _firstOpenScreen;

        public void Execute()
        {
            foreach (var item in _screenObjects)
            {
                var screen = item.GetComponent<IScreen>();
                if (screen.Type == _firstOpenScreen)
                {
                    screen.Open();
                }
                else
                {
                    screen.Close();
                }
            }
        }
    }
}
