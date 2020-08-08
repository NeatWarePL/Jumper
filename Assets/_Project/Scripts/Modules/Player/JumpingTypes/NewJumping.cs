using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJumping : Jump
{
    protected override void OnJump(float jumpTime)
    {
        Jump(jumpTime);
    }

    public void Jump(float time)
    {
        startingYPos = myEntityTransform.position.y;
        myEntityTransform.DOMoveY(gameConfig.playerJumpHeight, time).SetEase(Ease.OutQuad).OnComplete(() => FallDown(time));
    }

    public void FallDown(float time)
    {
        myEntityTransform.DOMoveY(startingYPos, time).SetEase(Ease.InQuad);
    }
}
