using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BeatJumping : Jump
{
    protected override IEnumerator JumpCoroutine(float jumpTime)
    {
        yield return new WaitForSeconds(0.11f);
        Jump(jumpTime);
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
}
