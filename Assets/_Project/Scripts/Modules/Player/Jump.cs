using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Module
{
    protected float startingYPos;

    private void OnEnable()
    {
        NW.Game.EventsProvider.onJump += OnJump;
    }

    private void OnDisable()
    {
        NW.Game.EventsProvider.onJump -= OnJump;
    }

    protected virtual void OnJump(float jumpTime)
    {
    }
}
