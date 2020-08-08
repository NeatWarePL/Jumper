using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMiddle : Module
{
    public GameObject myVfx;

    private void OnEnable()
    {
        BeatManager.onMidJump += PlayMyEffectIfAble;
    }


    private void OnDisable()
    {
        BeatManager.onMidJump -= PlayMyEffectIfAble;
    }

    private void PlayMyEffectIfAble()
    {
        Transform newMid = Instantiate(myVfx).transform;
        newMid.position = myEntityTransform.position;
    }
}
