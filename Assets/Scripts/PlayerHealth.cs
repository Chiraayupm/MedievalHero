using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 5;

    public TMP_Text healthText;

    public Animator HealthAnim;

    public void Start()
    {
        currentHealth = maxHealth;
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        HealthAnim.Play("HealthUpdate");

        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            GameObject.Find("Player").SetActive(false);
        }
    }

}
