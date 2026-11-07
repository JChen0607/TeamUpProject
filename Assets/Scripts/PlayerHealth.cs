
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public HealthUI healthUI;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthUI != null)
        {
            healthUI.SetMaxHearts(maxHealth);
            healthUI.UpdateHearts(currentHealth);
        }
        else
        {
            Debug.LogWarning("HealthUI is not assigned!");
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0 || damage <= 0)
            return;

        currentHealth = Mathf.Max(0, currentHealth - damage);

        if (healthUI != null)
        {
            healthUI.UpdateHearts(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Nova has died!");
        Destroy(gameObject);
    }
}
