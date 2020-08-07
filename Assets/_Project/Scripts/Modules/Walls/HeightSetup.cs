using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightSetup : Module
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SetupMyHeight();
        }
    }

    private void Start()
    {
        SetupMyHeight();
    }

    public void SetupMyHeight()
    {
        float height = 0f;
        int myWallId = WallsSpawner.currentWalls.IndexOf(myEntity.gameObject);
        if (BeatManager.currentBeatData != null)
        {
            BeatData dat = new BeatData();
            float myTimer = dat.GetTimeToFollowingBeat(BeatManager.firstJumpBeatData, myWallId + BeatManager.currentBeatId);
            if (myTimer == BeatManager.firstJumpTime || myTimer == BeatManager.secondJumpTime)
            {
                myTimer = dat.GetTimeToFollowingBeat(BeatManager.firstJumpBeatData, myWallId + BeatManager.currentBeatId + 1);
            }
            print("_________Updating my height_______");
            print("CURRENT BEAT ID: " + (myWallId + BeatManager.currentBeatId - 1));
            print("MY TIMER: " + myTimer);
            print("FIRST JUMP TIMER: " + BeatManager.firstJumpTime);
            print("SECOND JUMP TIMER: " + BeatManager.secondJumpTime);
            if (myTimer < BeatManager.firstJumpTime)
            {
                height = CalculateHeight(myTimer, BeatManager.firstJumpTime);
            }
            else
            {
                height = CalculateHeight(myTimer - BeatManager.firstJumpTime, BeatManager.secondJumpTime - BeatManager.firstJumpTime);
            }
        }
        myEntityTransform.position = new Vector3(myEntityTransform.position.x, height, myEntityTransform.position.z);
        print("Updating my height: " + height);
    }

    public float CalculateHeight(float myTime, float jumpTime)
    {
        float beatPercentage = myTime / jumpTime;
        print("PERCENTAGE: " + beatPercentage);
        float desiredHeight = beatPercentage * 2;
        if (desiredHeight <= 1)
        {
            desiredHeight *= 16;
        }
        else
        {
            desiredHeight = 1 + (1 - desiredHeight);
            desiredHeight *= 16;
        }
        return desiredHeight;
    }
}
