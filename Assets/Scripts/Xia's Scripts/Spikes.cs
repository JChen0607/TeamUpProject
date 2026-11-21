using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script  
    public HealthUI healthUI;  // Reference to the HealthUI script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.Die(); 
            playerHealth.TakeDamage(0);
         //   SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           // healthUI.UpdateHearts(playerHealth.currentHealth);

        }
    }
}
