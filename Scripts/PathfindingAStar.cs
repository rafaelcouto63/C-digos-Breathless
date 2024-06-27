using UnityEngine;
using UnityEngine.AI;

public class PathfindingAStar : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }


    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
