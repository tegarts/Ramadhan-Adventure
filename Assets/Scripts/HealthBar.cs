using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image FullHealth;
    [SerializeField] private Image HealthBarCurrent;
    // Start is called before the first frame update
    void Start()
    {
        FullHealth.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarCurrent.fillAmount = playerHealth.currentHealth / 10;
        // dibagi 10 soalnya gambarnya kalo 3 hati itu 0.3 nilainya
    }
}
