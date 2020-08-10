using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krzychu
{

    public class MainCamera : MonoBehaviour
    {
        public Ball ball;
        public float distanceFromCamera;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var vector = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, distanceFromCamera));
                Instantiate(ball, transform.position, transform.rotation).ThrowBall(vector);
            }

        }
    }

}