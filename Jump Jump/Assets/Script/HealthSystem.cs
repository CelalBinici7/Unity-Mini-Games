using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
   public Slider healthSlider;
   public float maxHealth = 100f;
    public float health;
    public float damage = 20f;
    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, 0.05f);

        if (health<=0)
        {
          
            ///LOSSEE
        }
    }
}
