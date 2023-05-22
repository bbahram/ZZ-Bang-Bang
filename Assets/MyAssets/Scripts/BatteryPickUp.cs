using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    [SerializeField] float lightRestore = 50f;
    [SerializeField] float angleRestore = 50f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(angleRestore);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(lightRestore);
            Destroy(gameObject);
        }
    }
}
