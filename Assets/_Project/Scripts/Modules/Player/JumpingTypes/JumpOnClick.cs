using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnClick : Module
{
    protected float startingYPos;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpDebug(gameConfig.playerJumpSpeed * 0.48f);
            //JumpMe();
        }
    }

    public void JumpDebug(float time)
    {
        if (!DOTween.IsTweening(myEntityTransform))
        {
            startingYPos = myEntityTransform.position.y;
            myEntityTransform.DOMoveY(gameConfig.playerJumpRange, time).SetEase(Ease.OutQuad).OnComplete(() => FallDownContinue(time));
        }
    }

    public void FallDownContinue(float time)
    {
        myEntityTransform.DOMoveY(startingYPos, time).SetEase(Ease.InQuad);
    }

    public void JumpMeOnPhysic()
    {
        myEntity.GetComponent<Rigidbody>().AddForce(Vector3.up * 1500f, ForceMode.Impulse);
    }
}
