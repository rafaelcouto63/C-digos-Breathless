using UnityEngine;
using UnityEngine.AI;


public class PointAndClick : MonoBehaviour
{
    public Transform target;
    public Camera myCamera;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 300))
            {
                target.position = hit.point + new Vector3(0, 0.5F, 0);
                agent.SetDestination(target.position);
            }
        }
    }
}
