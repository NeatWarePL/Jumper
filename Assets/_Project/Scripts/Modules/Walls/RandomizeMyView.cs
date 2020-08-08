using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMyView : Module
{
    public Transform wall;

    public Color[] colors;

    private void Start()
    {
        int randomColor = UnityEngine.Random.Range(0, colors.Length);
        float randomRotation = UnityEngine.Random.Range(-20f, 20f);
        float randomScaleY = UnityEngine.Random.Range(110f, 120f);
        float randomScaleZ = UnityEngine.Random.Range(80f, 250f);
        wall.localEulerAngles = new Vector3(randomRotation, 0f, 0f);
        wall.localScale = new Vector3(1, randomScaleY, randomScaleZ);
        wall.GetComponent<MeshRenderer>().material.color = (colors[randomColor]);
    }
}
