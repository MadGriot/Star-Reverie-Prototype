using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    private Vector3 targetPosition;
    private Actor actor;
    [SerializeField] private Animator actorAnimator;
    [SerializeField] private int maxMoveDistance = 4;
    private void Awake()
    {
        actor = GetComponent<Actor>();
        targetPosition = transform.position;
    }
    private void Update()
    {
        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
            transform.forward = moveDirection;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * 10f);
            actorAnimator.SetBool("IsWalking", true);

        }
        else
        {
            actorAnimator.SetBool("IsWalking", false);
        }
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    public List <GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition actorGridPosition = actor.GetGridPosition();
        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z < maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = actorGridPosition + offsetGridPosition;

            }
        }

        return validGridPositionList;
    }
}
