using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public MoveWall moveWallModule;

    public void SetupWallHeight(float wallHeight)
    {
        moveWallModule.SetupMyHeight(wallHeight);
    }
}
