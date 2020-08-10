using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krzychu
{

    public class Destroy : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 5);
        }
    }

}