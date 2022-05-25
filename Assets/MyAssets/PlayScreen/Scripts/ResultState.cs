using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;

namespace MT.PlayScreen
{
    public class ResultState : MonoBehaviour, IState
    {
        [SerializeField] private float _enterFadeOutDuration;
        [SerializeField] private float _enterFadeOutEndValue;

        void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            Fader.Instance.FadeOut(_enterFadeOutDuration, _enterFadeOutEndValue);
            ShowResult();
        }

        private void ShowResult()
        {

        }
    }
}

