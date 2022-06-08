using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.SelectMatchScreen
{
    public class CommonScreen : MonoBehaviour, IScreen, IStaticAwake
    {
        [SerializeField] private GameObject _entryStateObject;
        [SerializeField] private ScreenType _screenType;

        public ScreenType Type => _screenType;

        private IState _entryState;

        public void StaticAwake()
        {
            _entryState = _entryStateObject.GetComponent<IState>();
        }

        public void Open()
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
            _entryState.Enter();
        }

        public void CloseAsync()
        {
            if (!gameObject.activeSelf) return;

            gameObject.SetActive(false);
        }
    }
}
