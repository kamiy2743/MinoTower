using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class ScreenSwitcher : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private GameObject[] _screenObjects;
        [SerializeField] private ScreenType _firstOpenScreen;

        private Dictionary<ScreenType, IScreen> _screenDic = new Dictionary<ScreenType, IScreen>();

        public static ScreenSwitcher Instance => _instance;
        private static ScreenSwitcher _instance;

        public void StaticAwake()
        {
            _instance = this;

            foreach (var item in _screenObjects)
            {
                var screen = item.GetComponent<IScreen>();
                _screenDic[screen.Type] = screen;
            }
        }

        public void Initialize()
        {
            Switch(_firstOpenScreen);
        }

        public void Switch(ScreenType type)
        {
            foreach (var screen in _screenDic.Values)
            {
                if (screen.Type == type)
                {
                    screen.Open();
                }
                else
                {
                    screen.CloseAsync();
                }
            }
        }
    }
}
