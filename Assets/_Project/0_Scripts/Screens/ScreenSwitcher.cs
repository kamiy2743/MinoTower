using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

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
            SwitchAsync(_firstOpenScreen, 0, 0).Forget();
        }

        public async UniTask SwitchAsync(ScreenType type, float openDuration, float closeDuration)
        {
            var tasks = new List<UniTask>();
            foreach (var screen in _screenDic.Values)
            {
                tasks.Add(screen.CloseAsync(closeDuration));
            }
            await UniTask.WhenAll(tasks);

            await _screenDic[type].OpenAsync(openDuration);
        }
    }
}
