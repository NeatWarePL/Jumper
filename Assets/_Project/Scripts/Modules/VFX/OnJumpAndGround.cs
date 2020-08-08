using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnJumpAndGround : Module
{
    public GameObject VFXPrefab;

    private void OnEnable()
    {
        NW.Game.EventsProvider.onJump += Listener;
        NW.Game.EventsProvider.onGroundHit += Listener;
    }

    private void OnDisable()
    {
        NW.Game.EventsProvider.onJump -= Listener;
        NW.Game.EventsProvider.onGroundHit -= Listener;
    }

    private void Listener()
    {
        PlayGroundEffect();
    }

    private void Listener(float time)
    {
        PlayGroundEffect();
    }

    public void PlayGroundEffect()
    {
        if (VFXPrefab != null)
        {
            Transform newGo = Instantiate(VFXPrefab).transform;
            newGo.position = new Vector3(myEntityTransform.position.x, myEntityTransform.position.y - 1f, myEntityTransform.position.z);
        }
    }
}
