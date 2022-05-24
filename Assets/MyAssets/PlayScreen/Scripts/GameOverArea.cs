using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    public class GameOverArea : MonoBehaviour
    {
        private bool _isTrigger;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<MT.Blocks.Block>() != null)
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
