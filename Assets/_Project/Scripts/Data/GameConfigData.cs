using UnityEngine;

[CreateAssetMenu(menuName = "NW/Game/Game Config Data", fileName = "GameConfigData")]
public class GameConfigData : ScriptableObject
{
    [Header("PLAYER")]
    public float playerJumpHeight;
    public float playerSpeedOnConstant;
    public float playerSpeedOnDoTween;
    public float dashRange;
    public float playerSteeringSensitivity;
    [Header("WALLS")]
    public int numberOfWallsSpawnedAheadOfPlayer;
    public float randomizedRangeForXPositionObstacles;
    [Header("RHYTHMIZATION")]
    public int beatsDuringJump;
    public int beatsBeforeJump;
}
