using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Module : MonoBehaviour
{
    public Entity myEntity;
    protected Transform myEntityTransform;

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
        myEntityTransform = myEntity?.transform;
    }
}
