using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCell : MonoBehaviour
{
    public Rigidbody rigi;

    private void Start()
    {
        float randomForce = UnityEngine.Random.Range(120, 300);
        rigi.AddForce(randomForce, -50, 0);
    }
}
