using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantJump : Jump
{
    private void Start()
    {
        JumpDebug(gameConfig.playerJumpSpeed);
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
}
