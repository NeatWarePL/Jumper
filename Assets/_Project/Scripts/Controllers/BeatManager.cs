using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public GameObject menu;

    public static Action onJump;
    public static Action onSmash;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (menu.active)
            {
                menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        Rhythmizer.onBeat += RecognizeBeat;
    }

    private void OnDisable()
    {
        Rhythmizer.onBeat -= RecognizeBeat;
    }

    private void RecognizeBeat(BeatData beatData)
    {

    }
}
