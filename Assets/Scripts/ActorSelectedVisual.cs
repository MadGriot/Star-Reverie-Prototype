using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSelectedVisual : MonoBehaviour
{
    [SerializeField] private Actor actor;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        ActorActionSystem.Instance.OnSelectedActorChanged += ActorActionSystem_OnSeletedActorChanged;
        UpdateVisual();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActorActionSystem_OnSeletedActorChanged(object sender, EventArgs empty)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (ActorActionSystem.Instance.GetSelectedActor() == actor)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}
