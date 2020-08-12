using DG.Tweening;
using System.Collections;
using UnityEngine;

public class JumpWhileFlying : Jump
{
    private void OnEnable()
    {
        NW.Game.EventsProvider.onJumps += ManageJump;
    }

    private void OnDisable()
    {
        NW.Game.EventsProvider.onJumps -= ManageJump;
    }

    private void ManageJump(float[] jumps)
    {
        StartCoroutine(ManageJumpsCoroutine(jumps));
    }

    private IEnumerator ManageJumpsCoroutine(float[] jumps)
    {
        Jump(jumps[1] * 0.7f);
        yield return new WaitForSeconds(jumps[1] * 0.7f);
        FallDown(jumps[2]);
    }

    protected override void OnJump(float jumpTime)
    {
        //Jump(jumpTime);
    }

    public void Jump(float time)
    {
        startingYPos = myEntityTransform.position.y;
        myEntityTransform.DOMoveY(gameConfig.playerJumpHeight, time).SetEase(Ease.InQuint);
        //StartCoroutine(JumpDelay(time));
    }

    private IEnumerator JumpDelay(float time)
    {
        yield return new WaitForSeconds(time * 0.6f);
    }

    public void FallDown(float time)
    {
        myEntityTransform.DOMoveY(startingYPos, time).SetEase(Ease.OutQuint).OnComplete(GroundHitAction);
    }

    public void GroundHitAction()
    {
        NW.Game.EventsProvider.onGroundHit?.Invoke();
    }
}
