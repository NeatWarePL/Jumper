using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : Module
{
    public static Action<float> onJump;
    public static Action onSmash;
    public static Action<float> onWallCreate;
    int beatToJump;
    int currentBeat;
    BeatData jumpBeatData;

    private void Awake()
    {
        beatToJump = gameConfig.beatsBetweenJumps;
    }

    private void OnEnable()
    {
        Rhythmizer.onBeat += BeatAction;
    }

    private void OnDisable()
    {
        Rhythmizer.onBeat -= BeatAction;
    }

    private void Start()
    {
        currentBeat = beatToJump;
    }

    private void BeatAction(BeatData beatData)
    {
        if (beatToJump == currentBeat)
        {
            currentBeat = 0;
            for (int i = 0; i < beatData.followingBeatsTimestamps.Length; i++)
            {
                if (beatData.GetTimeToFollowingBeat(beatData, i) > 1.5f)
                {
                    beatToJump = i;
                    jumpBeatData = beatData;
                    break;
                }
            }
            onJump?.Invoke(beatData.GetTimeToFollowingBeat(beatData, beatToJump) * 0.48f);
        }
        else
        {
            float desiredHeight = GetNewWallHeight(beatData);

            onWallCreate?.Invoke(desiredHeight);
            onSmash?.Invoke();
        }
        currentBeat++;
    }

    private float GetNewWallHeight(BeatData beatData)
    {
        float newWallBeatData = RecognizeBeat(beatData);

        float beatPercentage = beatData.GetTimeToFollowingBeat(jumpBeatData, currentBeat) / beatData.GetTimeToFollowingBeat(jumpBeatData, beatToJump);
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

    private float RecognizeBeat(BeatData beatData)
    {
        float newTime = 0f;
        for (int i = 0; i < beatData.followingBeatsTimestamps.Length; i++)
        {
            if (beatData.GetTimeToFollowingBeat(beatData, i) > 1.5f + beatData.GetTimeToFollowingBeat(beatData, beatToJump))
            {
                //beatToJump = i;
                //jumpBeatData = beatData;
                newTime = beatData.GetTimeToFollowingBeat(beatData, i);
                break;
            }
        }
        newTime -= beatData.GetTimeToFollowingBeat(beatData, beatToJump);
        print(newTime);

        return newTime;
    }
}
