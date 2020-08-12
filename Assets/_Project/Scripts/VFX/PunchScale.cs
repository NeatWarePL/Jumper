using DG.Tweening;
using UnityEngine;

public class PunchScale : Module
{
    private void OnEnable()
    {
        BeatManager.onBeat += OnBeat;
        NW.Game.EventsProvider.onBounceFromGround += MidJump;
    }

    private void OnDisable()
    {
        BeatManager.onBeat -= OnBeat;
        NW.Game.EventsProvider.onBounceFromGround += MidJump;
    }

    public void OnBeat(BeatData beatData)
    {
        DOTween.Kill("PunchPlayer", true);
        myEntityTransform.DOPunchScale(Vector3.one * 0.2f, 0.2f).SetId("PunchPlayer");
    }

    public void MidJump()
    {
        //myEntityTransform.DOPunchScale(Vector3.one * 0.8f, 0.4f);
    }
}
