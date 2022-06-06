using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Multi
{
    [CreateAssetMenu(fileName = "CustomPropertyConfig", menuName = "ScriptableObjects/CustomPropertyConfig")]
    public class CustomPropertyConfig : ScriptableObject
    {
        public string IsMasterClientTurnKey = "IsMasterClientTurn";
    }
}
