using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : Module
{
    public static Action<float> onJump;
    public static Action onSmash;
    public static Action onWallCreate;
    int beatToJumpId;
    public static int currentBeatId;
    public static float firstJumpTime;
    public static float secondJumpTime;
    public static BeatData currentBeatData;
    public static BeatData firstJumpBeatData;

    private void Awake()
    {
        beatToJumpId = gameConfig.beatsBetweenJumps;
    }

    private void OnEnable()
    {
        Rhythmizer.onBeat += BeatActions;
    }

    private void OnDisable()
    {
        Rhythmizer.onBeat -= BeatActions;
    }

    private void Start()
    {
        currentBeatId = beatToJumpId;
    }

    private void BeatActions(BeatData beatData)
    {
        currentBeatData = beatData;
        if (beatToJumpId == currentBeatId)
        {
            currentBeatId = 0;
            SetupNewJumpTimes(beatData);
            onJump?.Invoke(firstJumpTime * 0.48f);
        }
        else
        {
            onWallCreate?.Invoke();
            onSmash?.Invoke();
        }
        currentBeatId++;
    }

    private void SetupNewJumpTimes(BeatData beatData)
    {
        for (int i = 0; i < beatData.followingBeatsTimestamps.Length; i++)
        {
            if (beatData.GetTimeToFollowingBeat(beatData, i) > 1.5f)
            {
                beatToJumpId = i;
                firstJumpBeatData = beatData;
                firstJumpTime = beatData.GetTimeToFollowingBeat(beatData, beatToJumpId);
                break;
            }
        }
        for (int i = 0; i < beatData.followingBeatsTimestamps.Length; i++)
        {
            if (beatData.GetTimeToFollowingBeat(beatData, i) > 1.5f + beatData.GetTimeToFollowingBeat(beatData, beatToJumpId))
            {
                secondJumpTime = beatData.GetTimeToFollowingBeat(beatData, i);
                break;
            }
        }
    }
}
