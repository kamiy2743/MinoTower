using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Stages
{
    public class GameOverArea : MonoBehaviour
    {
        private bool _isTrigger;

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.transform.parent.GetComponent<MT.Blocks.Block>() != null)
            {
                _isTrigger = true;
            }
        }

        void LateUpdate()
        {
            _isTrigger = false;
        }

        public bool IsTrigger()
        {
            return _isTrigger;
        }
    }
}
