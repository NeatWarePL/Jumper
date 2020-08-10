using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMyView : Module
{
    public Transform wall;
    public Color[] colors;
    public float randomRotationRange;
    public float randomScaleYFrom;
    public float randomScaleYTo;
    public float randomScaleZFrom;
    public float randomScaleZTo;

    private void Start()
    {
        int randomColor = UnityEngine.Random.Range(0, colors.Length);
        float randomRotation = UnityEngine.Random.Range(-randomRotationRange, randomRotationRange);
        float randomScaleY = UnityEngine.Random.Range(randomScaleYFrom, randomScaleYTo);
        float randomScaleZ = UnityEngine.Random.Range(randomScaleZFrom, randomScaleZTo);
        wall.localEulerAngles = new Vector3(randomRotation, 0f, 0f);
        wall.localScale = new Vector3(1, randomScaleY, randomScaleZ);
        wall.GetComponent<MeshRenderer>().material.color = (colors[randomColor]);
    }
}
