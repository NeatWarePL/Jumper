using UnityEngine;

public class OnWall : Module
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
