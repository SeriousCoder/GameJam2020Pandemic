using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveScript : MonoBehaviour
{
	private Camera mainCamera;
	private NavMeshAgent agent;
	
    // Start is called before the first frame update
    void Start()
    {
		mainCamera = Camera.main;
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
			Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, CurMousePos);

			if (rayHit.transform != null)
			{
				Vector3 newPoint = new Vector3(rayHit.point.x, rayHit.point.y);
				agent.SetDestination(newPoint);
			}
		}
    }
}
