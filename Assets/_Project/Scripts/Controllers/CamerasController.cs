using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamerasController : MonoBehaviour
{
    public Camera[] cameras;
    public Text debugText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameras[0].enabled = true;
            cameras[1].enabled = false;
            cameras[2].enabled = false;
            debugText.text = "CAMERA: 1";

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameras[0].enabled = false;
            cameras[1].enabled = true;
            cameras[2].enabled = false;
            debugText.text = "CAMERA: 2";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cameras[0].enabled = false;
            cameras[1].enabled = false;
            cameras[2].enabled = true;
            debugText.text = "CAMERA: 3";
        }
    }
}
