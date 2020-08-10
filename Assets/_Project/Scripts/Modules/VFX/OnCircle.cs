using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCircle : Module
{
    public GameObject myVfx;

    private void OnEnable()
    {
        NW.Game.EventsProvider.onCircleHit += PlayMyEffectIfAble;
    }


    private void OnDisable()
    {
        NW.Game.EventsProvider.onCircleHit -= PlayMyEffectIfAble;
    }

    private void PlayMyEffectIfAble()
    {
        Transform newMid = Instantiate(myVfx).transform;
        newMid.position = myEntityTransform.position;
    }
}
