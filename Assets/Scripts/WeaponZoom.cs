using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera;

    [SerializeField] private float zoomedOutFOV = 60f;

    [SerializeField] private float zoomedInFOV = 20f;

    [SerializeField] private float zoomOutSensitivity = 2f; // needed for zoom mouse sensitivity
    [SerializeField] private float zoomInSensitivity = .5f; // needed for zoom mouse sensitivity

    //private RigidbodyFirstPersonController fpsController; // needed for zoom mouse sensitivity // 196
    //196
    [SerializeField] private RigidbodyFirstPersonController fpsController;

    private bool zoomedInToggle = false;

    //private void Start() //196
    //{
    //    //fpsController = GetComponent<RigidbodyFirstPersonController>();
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                //zoomedInToggle = true;
                //fpsCamera.fieldOfView = zoomedInFOV;

                //fpsController.mouseLook.XSensitivity = zoomInSensitivity;
                //fpsController.mouseLook.YSensitivity = zoomInSensitivity;

                //201
                ZoomIn();
            }
            else
            {
                //zoomedInToggle = false;
                //fpsCamera.fieldOfView = zoomedOutFOV;

                //fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
                //fpsController.mouseLook.YSensitivity = zoomOutSensitivity;

                //201
                ZoomOut();
            }
        }
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;

        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;

        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }
}
