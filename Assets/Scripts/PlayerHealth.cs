using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 1;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for death state based on health (optional)
        if (health <= 0 && !isDead)
        {
            Die();
        }
       
        if(isDead == true)
        {
            RestartGame();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with tag
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
           //log
           // Debug.Log("Died");

            // Handle damage
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health--;
    }

    void Die()
    {
        //setting isDead to true
        isDead = true;

        // Destroy character
        Destroy(gameObject);

        // Stop the game 
        Time.timeScale = 0f;
    }
    
    void RestartGame()
    {

        SceneManager.LoadScene("GameScene");
        //reset time after death
        Time.timeScale = 1f;
    }
}
