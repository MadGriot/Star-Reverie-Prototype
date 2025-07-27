using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorActionSystem : MonoBehaviour
{
    public static ActorActionSystem Instance { get; private set; }
    public event EventHandler OnSelectedActorChanged;
    [SerializeField] private Actor selectedActor;
    [SerializeField] private LayerMask actorLayerMask;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more thatn one ActorActionSystem!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleActorSelection()) return;
            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());

            if (selectedActor.GetMoveAction().IsValidActionGridPosition(mouseGridPosition))
            {
                selectedActor.GetMoveAction().Move(mouseGridPosition);
            }
        }
    }
    private bool TryHandleActorSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, actorLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Actor>(out Actor actor))
            {
                SetSelectedActor(actor);
                return true;
            }
        }
        return false;
    }

    private void SetSelectedActor(Actor actor)
    {
        selectedActor = actor;
        OnSelectedActorChanged?.Invoke(this, EventArgs.Empty);
    }

    public Actor GetSelectedActor()
    {
        return selectedActor;
    }
}
