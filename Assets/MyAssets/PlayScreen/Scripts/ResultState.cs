using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.State;
using MT.Blocks;

namespace MT.PlayScreen
{
    public class ResultState : MonoBehaviour, IState
    {
        void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);
        }
    }
}

