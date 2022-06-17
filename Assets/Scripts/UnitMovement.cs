using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    public Camera MainCam;
    public NavMeshAgent agent;

    // Update is called once per frame. Sets a RayLine to the location on which the cursor was on when the left mouse button was pressed, by obtaining its position and then setting it as the destination for the player 
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){ 
            Ray RayLine = MainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(RayLine, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}