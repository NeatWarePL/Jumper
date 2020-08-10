using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krzychu
{

    public class Explosion : MonoBehaviour
    {
        public GameObject crushedObject;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void Boom()
        {
            Instantiate(crushedObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            print(collision.gameObject.name);
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                Boom();
            }
        }
    }

}