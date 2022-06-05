using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class EmptyState : MonoBehaviour, IState
    {
        public void Enter()
        {
            Debug.Log("empty state");
        }
    }
}
