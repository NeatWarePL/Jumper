using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : Module
{
    public Transform target;
    public float followDelay;
    [Header("Follow on axis")]
    public bool X;
    public bool Y;
    public bool Z;

    float posX;
    float posY;
    float posZ;

    private void Update()
    {
        UpdateMyPosition();
    }

    float startingXe;
    float startingYe;
    float startingZe;

    float startingXt;
    float startingYt;
    float startingZt;

    private void Start()
    {
        startingXe = myEntityTransform.position.x;
        startingYe = myEntityTransform.position.y;
        startingZe = myEntityTransform.position.z;

        startingXt = target.position.x;
        startingYt = target.position.y;
        startingZt = target.position.z;
    }

    private void UpdateMyPosition()
    {
        posX = myEntityTransform.position.x;
        posY = myEntityTransform.position.y;
        posZ = myEntityTransform.position.z;
        if (X)
        {
            posX = target.position.x + (startingXe - startingXt);
        }
        if (Y)
        {
            posY = target.position.y + (startingYe - startingYt);
        }
        if (Z)
        {
            posZ = target.position.z + (startingZe - startingZt);
        }
        Vector3 movement = new Vector3(posX, posY, posZ);
        //entityTransform.position = Vector3.Slerp(entityTransform.position, movement, followDelay);
        myEntityTransform.DOMove(movement, followDelay);
    }
}
