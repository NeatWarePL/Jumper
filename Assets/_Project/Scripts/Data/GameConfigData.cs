using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NW/Game/Game Config Data", fileName = "GameConfigData")]
public class GameConfigData : ScriptableObject
{
    [Header("PLAYER")]
    public float playerJumpHeight;
    public float playerSpeedOnConstant;
    public float playerSpeedOnDoTween;
    public float dashRange;
    [Header("WALLS")]
    public int numberOfWallsSpawnedAheadOfPlayer;
    [Header("RHYTHMIZATION")]
    public int beatsDuringJump;
    public int beatsBeforeJump;
}
