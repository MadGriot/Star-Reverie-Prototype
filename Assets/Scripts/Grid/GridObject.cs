using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    // Start is called before the first frame update
    private GridPosition gridPosition;
    private GridSystem gridSystem;
    private List<Actor> actors;
    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        actors = new List<Actor>();
    }

    public override string ToString()
    {
        string actorString = "";
        foreach (Actor actor in actors)
        {
            actorString += actor + "\n";
        }
        return gridPosition.ToString() + "\n" + actorString;
    }

    public void AddActor(Actor actor)
    {
        actors.Add(actor);
    }
    public void RemoveActor(Actor actor)
    {
        actors.Remove(actor);
    }
    public List<Actor> GetActors()
    {
        return actors;
    }
}
