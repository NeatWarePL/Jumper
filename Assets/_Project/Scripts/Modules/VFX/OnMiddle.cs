using UnityEngine;

public class OnMiddle : Module
{
    public GameObject myVfx;

    private void OnEnable()
    {
        NW.Game.EventsProvider.onBounceFromGround += PlayMyEffectIfAble;
    }


    private void OnDisable()
    {
        NW.Game.EventsProvider.onBounceFromGround -= PlayMyEffectIfAble;
    }

    private void PlayMyEffectIfAble()
    {
        Transform newMid = Instantiate(myVfx).transform;
        newMid.position = myEntityTransform.position;
    }
}
