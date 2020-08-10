using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BeatJumpingWithDash : Jump
{
    protected override void OnJump(float jumpTime)
    {
        Jump(jumpTime);
    }

    public void Jump(float time)
    {
        startingYPos = myEntityTransform.position.y;
        myEntityTransform.DOMoveY(gameConfig.playerJumpHeight, time * 0.7f).SetEase(Ease.OutQuad).OnComplete(() => Dash(time));
        //myEntityTransform.DOMoveY(gameConfig.playerJumpHeight, time).SetEase(Ease.InQuint).OnComplete(() => FallDown(time));
    }

    public void Dash(float time)
    {
        myEntityTransform.DOMoveX(myEntityTransform.position.x + 50f, 0.1f).SetEase(Ease.Linear).OnComplete(() => FallDown(time));
        //myEntityTransform.DOMoveY(gameConfig.playerJumpHeight, time * 0.7f).SetEase(Ease.OutQuad).OnComplete(() => Dash(time * 0.3f));
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
