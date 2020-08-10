using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Module : MonoBehaviour
{
    public Entity myEntity;
    protected Transform myEntityTransform;
    protected Rigidbody myEntityRigidbody;

    [HideInInspector]
    [InjectOptional] public GameConfigData gameConfig;
    [HideInInspector]
    [InjectOptional] public RhythmizationConfig rhythmizationConfig;

    private void Awake()
    {
        if (myEntity == null)
        {
            myEntity = GetComponentInParent<Entity>();
        }
        if (myEntity != null)
        {
            myEntityTransform = myEntity.transform;
            //if (myEntity.GetComponent<Rigidbody>() != null)
            //{
            //    myEntityRigidbody = myEntity.GetComponent<Rigidbody>();
            //}
        }
    }
}
