using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    [CreateAssetMenu(fileName = "PlayScreenConfig", menuName = "ScriptableObjects/PlayScreenConfig")]
    public class PlayScreenConfig : ScriptableObject
    {
        public SEType OnSpawnSE;
        public SEType OnRotateSE;
    }
}
