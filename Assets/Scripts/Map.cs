using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : SceneSingleton<Map>
{
    
    public StarterBoost StarterBoost;
    public Transform CameraCenter;
    public Transform CameraStart;
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    public CinemachineDollyCart DollyCart;

    private void Start()
    {
        
        var path = (DollyCart.m_Path as CinemachineSmoothPath);
        path.m_Waypoints[0].position = CameraCenter.position;
        path.m_Waypoints[1].position = CameraStart.position;
      
        CinemachineVirtualCamera.gameObject.SetActive(true);
    }
    private void Update()
    {
        if(DollyCart.m_Position == 1)
        {
            CinemachineVirtualCamera.gameObject.SetActive(false);
            Player.Instance.PlayerCamera.gameObject.SetActive(true);
        }
    }
}
