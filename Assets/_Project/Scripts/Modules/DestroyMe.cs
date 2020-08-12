public class DestroyMe : Module
{
    private void Update()
    {
        if (myEntityTransform.position.x + 300f < NW.Game.EventsProvider.player.position.x)
        {
            Destroy(myEntity.gameObject);
        }
    }
}
