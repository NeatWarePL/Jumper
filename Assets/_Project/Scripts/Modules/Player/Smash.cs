using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Smash : Module
{
    private void OnEnable()
    {
        BeatManager.onSmash += OnBeat;
    }

    private void OnDisable()
    {
        BeatManager.onSmash -= OnBeat;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SmashForward();
        }
    }

    public void OnBeat()
    {
        StartCoroutine(SmashCoroutine());
    }

    public void SmashForward()
    {
        NW.Game.EventsProvider.onSmash?.Invoke();
        myEntityTransform.DOMoveX(myEntityTransform.position.x + gameConfig.playerSmashRange, gameConfig.playerSmashSpeed).SetEase(Ease.Linear);
    }

    public IEnumerator SmashCoroutine()
    {
        yield return new WaitForSeconds(0.11f);
        NW.Game.EventsProvider.onSmash?.Invoke();
        myEntityTransform.DOMoveX(myEntityTransform.position.x + gameConfig.playerSmashRange, gameConfig.playerSmashSpeed).SetEase(Ease.Linear);
    }
}
