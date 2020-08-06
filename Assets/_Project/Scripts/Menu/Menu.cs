using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject songList;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (songList.active)
            {
                songList.SetActive(false);
            }
            else
            {
                songList.SetActive(true);
            }
        }
    }
}
