using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.OptionScreen
{
    public class WaitForPlayerActionState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private SettingSlider _BGMSlider;
        [SerializeField] private SettingSlider _SESlider;
        [SerializeField] private CustomButton _backButton;
        [Space(20)]
        [SerializeField] private ToTopScreenState _toTopScreenState;

        public void StaticStart()
        {
            _backButton.AddListener(() =>
            {
                Tonext();
            });
        }

        public void Enter()
        {
            _BGMSlider.SetIsListened(true);
            _SESlider.SetIsListened(true);
            _backButton.SetIsListened(true);
        }

        private void Tonext()
        {
            _BGMSlider.SetIsListened(false);
            _SESlider.SetIsListened(false);
            _backButton.SetIsListened(false);
            _toTopScreenState.Enter();
        }
    }
}
