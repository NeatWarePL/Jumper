using UnityEngine;

namespace Krzychu
{

    public class Explosion : MonoBehaviour
    {
        public GameObject[] crushedObjects;

        private void Boom()
        {
            int randomWallId = UnityEngine.Random.Range(0, crushedObjects.Length);
            print(randomWallId);
            Instantiate(crushedObjects[randomWallId], transform.position, transform.rotation);
            Destroy(gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                //NW.Game.EventsProvider.onWallHit?.Invoke();
                Boom();
            }
        }
    }

}
