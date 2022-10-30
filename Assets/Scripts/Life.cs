using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject gameOver;
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameOver.SetActive(true);
            gameState.Pause();
        }
    }

    void TakeDamage() {
        currentHealth -= 10;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target"){
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
    
}
