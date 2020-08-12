using UnityEngine;
using UnityEngine.Events;

public class OnCircleHit : Module
{
    public UnityEvent onMeHit;
    public UnityEvent perfectEvent;

    private void OnEnable()
    {
        ObstacleHitController.onCircleHit += CircleHit;
    }

    private void OnDisable()
    {
        ObstacleHitController.onCircleHit -= CircleHit;
    }

    private void CircleHit(GameObject obj)
    {
        if (obj == myEntity.gameObject)
        {
            if (Mathf.Abs(NW.Game.EventsProvider.player.position.z - myEntityTransform.position.z) < 5)
            {
                onMeHit?.Invoke();
                perfectEvent?.Invoke();
            }
        }
    }
}
