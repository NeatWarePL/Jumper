using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PunchScale : Module
{
    private void OnEnable()
    {
        BeatManager.onBeat += OnBeat;
        BeatManager.onMidJump += MidJump;
    }

    private void OnDisable()
    {
        BeatManager.onBeat -= OnBeat;
        BeatManager.onMidJump += MidJump;
    }

    public void OnBeat()
    {
        myEntityTransform.DOPunchScale(Vector3.one * 0.2f, 0.2f);
    }

    public void MidJump()
    {
        //myEntityTransform.DOPunchScale(Vector3.one * 0.8f, 0.4f);
    }
}