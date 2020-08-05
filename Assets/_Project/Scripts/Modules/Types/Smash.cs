using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Smash : Module
{
    bool st;

    private void OnEnable()
    {
        Rhythmizer.onBeat += OnBeat;
    }

    private void OnDisable()
    {
        Rhythmizer.onBeat -= OnBeat;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SmashForward();
        }
    }

    public void OnBeat(BeatData beatData)
    {
        if (st)
        {
            StartCoroutine(SmashCoroutine());
            st = false;
        }
        else
        {
            st = true;
        }
    }

    public void SmashForward()
    {
        NW.Game.EventsProvider.onSmash?.Invoke();
        myEntityTransform.DOMoveX(myEntityTransform.position.x + gameConfig.playerSmashRange, gameConfig.playerSmashSpeed).SetEase(Ease.Linear);
    }

    public IEnumerator SmashCoroutine()
    {
        print("WHAT?");
        yield return new WaitForSeconds(0.11f);
        NW.Game.EventsProvider.onSmash?.Invoke();
        myEntityTransform.DOMoveX(myEntityTransform.position.x + gameConfig.playerSmashRange, gameConfig.playerSmashSpeed).SetEase(Ease.Linear);
    }
}
