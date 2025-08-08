using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    protected Actor actor;
    protected bool isActive;
    public Action onActionComplete;
    protected virtual void Awake()
    {
        actor = GetComponent<Actor>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract string GetActionName();
}
