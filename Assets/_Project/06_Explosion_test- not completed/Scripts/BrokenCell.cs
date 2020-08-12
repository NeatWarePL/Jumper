using UnityEngine;

public class BrokenCell : MonoBehaviour
{
    public Rigidbody rigi;
    private Transform playerT;

    private void Awake()
    {
        playerT = NW.Game.EventsProvider.player;
    }

    private void Start()
    {
        float randomForce = UnityEngine.Random.Range(300, 310);
        float pikachu = (15 - Mathf.Abs(transform.position.z - playerT.position.z)) * 0.2f;
        float raichu = (15 - Mathf.Abs(transform.position.y - playerT.position.y)) * 0.2f;
        randomForce *= pikachu;
        bool charmander = false;
        if (Mathf.Abs(transform.position.z - playerT.position.z) > 8)
        {
            rigi.drag = 100f;
        }
        else
        {
            rigi.AddForce(randomForce * 4, -50 * 4, 0);
            charmander = true;
        }
        //if (Mathf.Abs(transform.position.y - playerT.position.y) > 12)
        //{
        //    rigi.drag = 100f;
        //}
        //else
        //{
        //    charmander = true;
        //}
        //if (charmander)
        //{
        //}
    }
}
