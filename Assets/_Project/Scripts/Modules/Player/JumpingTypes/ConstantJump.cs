using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantJump : Jump
{
    public float jumpspeed;

    private void Start()
    {
        JumpDebug(jumpspeed);
    }

    public void JumpDebug(float time)
    {
        startingYPos = myEntityTransform.position.y;
        myEntityTransform.DOMoveY(gameConfig.playerJumpHeight, time).SetEase(Ease.Linear).OnComplete(() => FallDownContinue(time));
    }

    public void FallDownContinue(float time)
    {
        myEntityTransform.DOMoveY(startingYPos, time).SetEase(Ease.Linear).OnComplete(() => JumpDebug(time));
    }
}
