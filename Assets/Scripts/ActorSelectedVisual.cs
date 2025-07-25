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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
