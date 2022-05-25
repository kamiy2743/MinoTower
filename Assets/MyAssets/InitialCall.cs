using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class InitialCall : MonoBehaviour
    {
        [SerializeField] private GameObject _topScreenObject;
        [SerializeField] private MT.TopScreen.States.EnterState _topScreenEnterState;
        [SerializeField] private GameObject _playScreenObject;
        [SerializeField] private MT.PlayScreen.States.EnterState _playScreenEnterState;

        // Start is called before the first frame update
        void Start()
        {
            if (_topScreenObject.activeSelf)
            {
                _topScreenEnterState.Enter();
                return;
            }

            if (_playScreenObject.activeSelf)
            {
                _playScreenEnterState.Enter();
                return;
            }
        }
    }
}
