using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krzychu
{
    public class Move : MonoBehaviour
    {
        public float speed;

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * speed);
        }
    }
}