using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens;

namespace MT
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject[] _screenObjects;
        [SerializeField] private ScreenType _firstOpenScreen;

        private IScreen[] _screens;

        void Awake()
        {
            var screenList = new List<IScreen>();
            foreach (var item in _screenObjects)
            {
                var screen = item.GetComponent<IScreen>();
                screenList.Add(screen);
            }
            _screens = screenList.ToArray();
        }

        // Start is called before the first frame update
        void Start()
        {
            foreach (var screen in _screens)
            {
                if (screen.ScreenType == _firstOpenScreen)
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
