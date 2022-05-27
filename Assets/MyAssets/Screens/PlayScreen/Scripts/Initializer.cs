using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Blocks;

namespace MT.Screens.PlayScreen
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private PlayData _playData;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ScreenScroller _screenScroller;

        public void Execute()
        {
            _playData.Initialize();
            _blockStore.Initialize();
            _resultUI.Initialize();
            _rotateButton.Initialize();
            _screenScroller.Initialize();
        }
    }
}
