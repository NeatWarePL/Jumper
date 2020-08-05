using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Module : MonoBehaviour
{
    protected Entity myEntity;
    protected Transform myEntityTransform;

    [HideInInspector]
    [InjectOptional] public GameConfigData gameConfig;

    private void Awake()
    {
        myEntity = GetComponentInParent<Entity>();
        myEntityTransform = myEntity?.transform;
    }
}
