using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockConfig", menuName = "ScriptableObjects/BlockConfig")]
public class BlockConfig : ScriptableObject
{
    public float SpawnAnimationDuration = 0.4f;
    public float RotateAngle = -45;
    public float RotateDuration = 0.2f;
    public float SleepThreshold = 0.3f;
}
