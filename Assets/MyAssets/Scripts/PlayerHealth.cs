using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoint = 100f;
    [SerializeField] TextMeshProUGUI healthUI;
    public void TakeDamage(float damage)
    {
        hitPoint -= damage;
        healthUI.text = hitPoint.ToString();
        if (hitPoint <= 0)
        {
            FindObjectOfType<DeathHandler>().HandleDeath();
            //Destroy(gameObject);
        }
    }
}
