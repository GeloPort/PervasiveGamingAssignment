using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineFreeLook FollowCam;
    bool isTopDown = false;
    private string inputYName;
    private string inputXName;

    // Start is called before the first frame update. Defines the priority of the Follow Camera (3rd person) to 2 and both axis of that camera to simpler names to be called by other functions
    void Start()
    {
        FollowCam.m_Priority = 2;
        inputYName = FollowCam.m_YAxis.m_InputAxisName;
        inputXName = FollowCam.m_XAxis.m_InputAxisName;
    }

    // Update is called once per frame. Calls for CameraSwitch and AxisMechanic scripts
    void Update()
    {
        CameraSwitch();
        AxisMechanic();
    }

    // CameraSwitch switches between the Follow and Top View Cameras once M is pressed, by switching the priority value of the Follow Camera between 2 and 0, while the Top Down Camera stays with a priority value of 1
    private void CameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isTopDown)
        {
            FollowCam.m_Priority = 0;
            isTopDown = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && isTopDown)
        {
            FollowCam.m_Priority = 2;
            isTopDown = false;

        }
    }

    // AxisMechanic ensures that the camera only moves while the right mouse button (1) is pressed. Once the Right Mouse button is pressed, sets their names to their default, while setting said names to blank and values to 0, if the player isn't pressing RMB
    private void AxisMechanic()
    {
        if (Input.GetMouseButton(1))
        {
            FollowCam.m_YAxis.m_InputAxisName = inputYName;
            FollowCam.m_XAxis.m_InputAxisName = inputXName;
        }
        else
        {
            FollowCam.m_XAxis.m_InputAxisName = "";
            FollowCam.m_XAxis.m_InputAxisValue = 0;
            FollowCam.m_YAxis.m_InputAxisName = "";
            FollowCam.m_YAxis.m_InputAxisValue = 0;
        }
    }
}
