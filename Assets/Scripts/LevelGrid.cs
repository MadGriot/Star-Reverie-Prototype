using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Transform gridDebugObjectPrefab;
    public static LevelGrid Instance { get; private set; }
    private GridSystem gridSystem;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one LevelGrid!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    public void AddActorAtGridPosition(GridPosition gridPosition, Actor actor)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddActor(actor);
    }

    public List<Actor> GetActorsAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetActors();
    }

    public void RemoveActorAtGridPosition(GridPosition gridPosition, Actor actor)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveActor(actor);
    }

    public void ActorMovedGridPosition(Actor actor, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveActorAtGridPosition(fromGridPosition, actor);

        AddActorAtGridPosition(toGridPosition, actor);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);

    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);
    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

    public bool HasAnyActorGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.HasAnyActor();
    }

}
