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

        public async UniTask Initialize()
        {
            await Hide(0);
        }

        public async UniTask Show(float fadeDuration)
        {
            await _commonUI.Show(fadeDuration);
        }

        public async UniTask Hide(float fadeDuration)
        {
            await _commonUI.Hide(fadeDuration);
        }
    }
}
