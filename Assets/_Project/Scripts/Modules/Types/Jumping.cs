using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Jumping : Module
{
    private float startingYPos;

    private void OnEnable()
    {
        Rhythmizer.onBeat += OnBeatListener;
    }

    private void OnDisable()
    {
        Rhythmizer.onBeat -= OnBeatListener;
    }

    private void OnBeatListener(BeatData beatData)
    {
        StartCoroutine(WTF(beatData));
    }

    private IEnumerator WTF(BeatData beatData)
    {
        yield return new WaitForSeconds(0.11f);
        if (!DOTween.IsTweening(myEntityTransform))
        {
            Jump(beatData.GetTimeToFollowingBeat(beatData, 2) * 0.48f);
        }
    }

    public void Jump(float time)
    {
        startingYPos = myEntityTransform.position.y;
        myEntityTransform.DOMoveY(gameConfig.playerJumpRange, time).SetEase(Ease.OutQuad).OnComplete(() => FallDown(time));
    }

    public void FallDown(float time)
    {
        myEntityTransform.DOMoveY(startingYPos, time).SetEase(Ease.InQuad);
    }

    #region Debug
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpDebug(gameConfig.playerJumpSpeed);
        }
    }

    public void JumpDebug(float time)
    {
        startingYPos = myEntityTransform.position.y;
        myEntityTransform.DOMoveY(gameConfig.playerJumpRange, time).SetEase(Ease.OutQuad).OnComplete(() => FallDownContinue(time));
    }

    public void FallDownContinue(float time)
    {
        myEntityTransform.DOMoveY(startingYPos, time).SetEase(Ease.InQuad).OnComplete(() => JumpDebug(time));
    }
    #endregion
}
