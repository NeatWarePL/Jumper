using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NW/Game/Game Config Data", fileName = "GameConfigData")]
public class GameConfigData : ScriptableObject
{
    [Header("PLAYER")]
    public float playerSmashRange;
    public float playerSmashSpeed;
    public float playerJumpRange;
    public float playerJumpSpeed;
    [Header("WALLS")]
    public float wallsCount;
    public float wallsRange;
    [Header("RHYTHMIZATION")]
    public int beatsBetweenJumps;
}
