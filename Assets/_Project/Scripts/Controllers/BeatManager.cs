using NW.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : Module
{
    public static Action onWallCreate;
    public static Action<BeatData> onBeat;
    public static Action onMidJump;

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

    public IEnumerator BeatActionDelay(BeatData beatData)
    {
        yield return new WaitForSeconds(rhythmizationConfig.GetMusicDelay);
        if (beatAfterJumpId == 0)
        {
            onMidJump?.Invoke();
        }
        if (beatAfterJumpId % 2 == 0)
        {
            NW.Game.EventsProvider.onCircleHit?.Invoke();
        }
        beatAfterJumpId++;
        onBeat?.Invoke(beatData);
        if (beatAfterJumpId == gameConfig.beatsBeforeJump + gameConfig.beatsDuringJump)
        {
            beatAfterJumpId = 0;
            NW.Game.EventsProvider.onJump?.Invoke(beatData.GetTimeToFollowingBeat(beatData, gameConfig.beatsDuringJump) * 0.49f);
        }
    }
}
