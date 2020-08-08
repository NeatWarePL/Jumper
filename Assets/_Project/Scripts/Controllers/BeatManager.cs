using NW.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : Module
{
    public static Action onWallCreate;
    public static Action onBeat;
    public static Action onMidJump;

    private void OnEnable()
    {
        Rhythmizer.onBeat += BeatActions;
    }

    private void OnDisable()
    {
        Rhythmizer.onBeat -= BeatActions;
    }

    int kiszka = 0;

    private void BeatActions(BeatData beatData)
    {
        StartCoroutine(BeatActionDelay(beatData));
    }

    public IEnumerator BeatActionDelay(BeatData beatData)
    {
        yield return new WaitForSeconds(rhythmizationConfig.GetMusicDelay);
        print(kiszka);
        if (kiszka == 0)
        {
            onMidJump?.Invoke();
        }
        kiszka++;
        onBeat?.Invoke();
        if (kiszka == gameConfig.beatsBeforeJump + gameConfig.beatsDuringJump)
        {
            //onWallCreate?.Invoke();
            kiszka = 0;
            NW.Game.EventsProvider.onJump?.Invoke(beatData.GetTimeToFollowingBeat(beatData, gameConfig.beatsDuringJump) * 0.49f);
        }
    }
}
