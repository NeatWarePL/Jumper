using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundHit : MonoBehaviour
{
    public Transform mySprite;
    public float scale;

    private void Start()
    {
        mySprite.DOScale(Vector3.one * scale, 0.3f);
        mySprite.GetComponent<SpriteRenderer>().DOColor(new Color(Color.white.r, Color.white.g, Color.white.b, 0), 0.5f);
    }
}
