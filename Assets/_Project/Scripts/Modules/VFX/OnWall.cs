using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWall : Module
{
    public GameObject myVfx;

    private void OnEnable()
    {
        //NW.Game.EventsProvider.onWallHit += PlayMyEffectIfAble;
        BeatManager.onMidJump += PlayMyEffectIfAble;
    }


    private void OnDisable()
    {
        //NW.Game.EventsProvider.onWallHit -= PlayMyEffectIfAble;
        BeatManager.onMidJump -= PlayMyEffectIfAble;
    }

    private void PlayMyEffectIfAble()
    {
        Transform newMid = Instantiate(myVfx).transform;
        newMid.position = myEntityTransform.position;
    }
}
