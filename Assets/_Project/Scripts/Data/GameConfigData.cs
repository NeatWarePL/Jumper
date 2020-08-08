using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NW/Game/Game Config Data", fileName = "GameConfigData")]
public class GameConfigData : ScriptableObject
{
    [Header("PLAYER")]
    public int beatsDuringJump;
    public int beatsBeforeJump;
    public float playerJumpHeight;
    public float playerSpeed;
    [Header("WALLS")]
    public float wallsCount;
    public float wallsRange;
    [Header("RHYTHMIZATION")]
    public int beatsBetweenJumps;
}
