using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.MatchMakingScreen
{
    public class FriendMatchUI : MonoBehaviour, IStaticAwake
    {
        private CommonUI _commonUI;

        public void StaticAwake()
        {
            _commonUI = GetComponent<CommonUI>();
        }

        public async UniTask InitializeAsync()
        {
            await HideAsync(0);
        }

        public async UniTask ShowAsync(float fadeDuration)
        {
            await _commonUI.ShowAsync(fadeDuration);
        }

        public async UniTask HideAsync(float fadeDuration)
        {
            await _commonUI.HideAsync(fadeDuration);
        }
    }
}
