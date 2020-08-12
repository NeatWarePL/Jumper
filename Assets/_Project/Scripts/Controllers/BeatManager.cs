using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : Module
{
    public static Action onWallCreate;
    public static Action<BeatData> onBeat;
    public static Action<BeatData> onBeatSpawnCircle;
    public static Action<BeatData> onBeatSpawnWall;

    private void OnEnable()
    {
        Rhythmizer.onBeat += BeatActions;
    }

    private void OnDisable()
    {
        Rhythmizer.onBeat -= BeatActions;
    }

    int beatAfterJumpId = 0;

    private void BeatActions(BeatData beatData)
    {
        StartCoroutine(BeatActionDelay(beatData));
    }

    private void FireInvokeIfAble()
    {
        if (beatAfterJumpId == 0)
        {
            NW.Game.EventsProvider.onBounceFromGround?.Invoke();
            NW.Game.EventsProvider.onWallHit?.Invoke();
        }
        if (/*beatAfterJumpId % 2 == 0 &&*/ beatAfterJumpId != 0 && beatAfterJumpId != gameConfig.beatsBeforeJump + gameConfig.beatsDuringJump && beatAfterJumpId != 1)
        {
            //onBeatSpawnCircle?.Invoke();
            NW.Game.EventsProvider.onCircleHit?.Invoke();
        }
    }

    public IEnumerator BeatActionDelay(BeatData beatData)
    {
        yield return new WaitForSeconds(rhythmizationConfig.GetMusicDelay);
        FireInvokeIfAble();
        beatAfterJumpId++;
        onBeat?.Invoke(beatData);
        if (beatAfterJumpId == gameConfig.beatsBeforeJump + gameConfig.beatsDuringJump)
        {
            beatAfterJumpId = 0;
            List<float> jumps = new List<float>();
            for (int i = 0; i < gameConfig.beatsDuringJump + 1; i++)
            {
                jumps.Add(beatData.GetTimeToFollowingBeat(beatData, i));
            }
            NW.Game.EventsProvider.onJump?.Invoke(beatData.GetTimeToFollowingBeat(beatData, gameConfig.beatsDuringJump) * 0.49f);
            NW.Game.EventsProvider.onJumps?.Invoke(jumps.ToArray());
        }
    }
}
