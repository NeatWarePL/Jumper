using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krzychu
{

    public class Ball : MonoBehaviour
    {
        private Rigidbody rigy_b;
        public float force;

        private void Awake()
        {
            rigy_b = gameObject.GetComponent<Rigidbody>();
        }

        public void ThrowBall(Vector3 destination)
        {
            rigy_b.AddForce(destination * force);
        }
    }

}