using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Module
{
    protected float startingYPos;

    private void OnEnable()
    {
        BeatManager.onJump += OnBeatListener;
    }

    private void OnDisable()
    {
        BeatManager.onJump -= OnBeatListener;
    }

    protected void OnBeatListener(float jumpTime)
    {
        StartCoroutine(JumpCoroutine(jumpTime));
    }

    protected virtual IEnumerator JumpCoroutine(float jumpTime)
    {
        yield return null;
    }
}
