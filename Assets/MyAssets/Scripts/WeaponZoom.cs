using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInFOV = 20f;
    [SerializeField] float zoomInSensitivity = 0.5f;
    [SerializeField] float zoomOutSensitivity = 2f;

    private void OnDisable()
    {
        fpsCamera.fieldOfView = zoomOutFOV;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            fpsCamera.fieldOfView = zoomInFOV;
            fpsController.mouseLook.XSensitivity = zoomInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomInSensitivity;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            fpsCamera.fieldOfView = zoomOutFOV;
            fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
        }
    }
}
