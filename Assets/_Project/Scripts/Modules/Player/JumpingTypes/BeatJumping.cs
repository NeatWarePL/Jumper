using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BeatJumping : Jump
{
    protected override void OnJump(float jumpTime)
    {
        Jump(jumpTime);
    }

    public void Jump(float time)
    {
        startingYPos = myEntityTransform.position.y;
        myEntityTransform.DOMoveY(gameConfig.playerJumpHeight, time).SetEase(Ease.OutQuad).OnComplete(() => FallDown(time));
        //myEntityTransform.DOMoveY(gameConfig.playerJumpHeight, time).SetEase(Ease.InQuint).OnComplete(() => FallDown(time));
    }

    public void Dash(float time)
    {
    }

    public void FallDown(float time)
    {
        myEntityTransform.DOMoveY(startingYPos, time).SetEase(Ease.InQuad).OnComplete(GroundHitAction);
        //myEntityTransform.DOMoveY(startingYPos, time).SetEase(Ease.OutQuint).OnComplete(GroundHitAction);
    }

    public void GroundHitAction()
    {
        NW.Game.EventsProvider.onGroundHit?.Invoke();
    }
}
