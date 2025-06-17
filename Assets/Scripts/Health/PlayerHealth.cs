using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importing UnityEngine.UI to use UI elements like Text, Image, etc.
using UnityEngine.Events; // Importing UnityEngine.Events to use UnityEvent for event handling

public class PlayerHealth : MonoBehaviour
{
    //Changed to public so that it could be called from other scripts without needing to use GetComponent<PlayerHealth>().
    public float maxHealth; // Player's maximum health, set to 100 by default

    //Changed to public so that it could be called from other scripts without needing to use GetComponent<PlayerHealth>().
    public float currentHealth; // Player's current health, initialized to maxHealth

    public Image healthBarImage; // Reference to the UI Image component that represents the health bar

    public LivesManager LivesManager; // Reference to the LivesManager component to manage player lives

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float amount)
    {
        currentHealth = currentHealth + amount;
        //Using currentHealth += amount; would also work the same way

        if (currentHealth > maxHealth) // Check if current health exceeds maximum health
        {
            currentHealth = maxHealth; // If it does, set current health to maximum health number
        }

        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0) // Check if current health is less than or equal to zero
        {
            currentHealth = 0; // If it is, set current health to zero. This is to avoid negative health values

            //InstaKill();

            gameObject.SetActive(false);

            gameObject.transform.position = new Vector3(0.0f, -3.0f, 0.0f); // Move the game object to the starting position of (0, -3, 0)

            if (LivesManager != null) // Check if LivesManager reference is assigned in the Inspector
            {
                LivesManager.RemoveLife(); // Call the RemoveLife method from LivesManager to decrement the player's lives
            }
            else
            {
                Debug.LogWarning("LivesManager reference is not assigned in PlayerHealth script."); // Log a warning if LivesManager is not assigned
            }

            //GetComponent<LivesManager>().RemoveLife(); // Call the RemoveLife method from LivesManager to decrement the player's lives

        }

        UpdateHealthBar();
    }

    
    public void InstaKill()
    {
        Death deathComponent = GetComponent<Death>();

        if (deathComponent != null)
        {
            deathComponent.Die(); // Call the Die method from the Death component if it exists

            Debug.Log("Player Ship Destroyed.");
        }

        UpdateHealthBar();
    }

    // This method updates the health bar UI based on the current health
    public float ComputeHealthPercentage()
    {
        return currentHealth / maxHealth; // Calculate the health percentage by dividing current health by maximum health
    }

    public void UpdateHealthBar()
    {
        if (healthBarImage != null) // Check if the health bar image reference is assigned in the Inspector
        {
            healthBarImage.fillAmount = ComputeHealthPercentage(); // Update the health bar UI based on the current health percentage
        }
    }

    //Note: bool is a data type in C# that can only be true or false
    public bool IsAlive()
    {
        // if our health is greater than zero
        if (currentHealth > 0)
        {
            return true;
        }

        // otherwise, return false
        return false;
    }


    //Note for self: Using public also allows the variable to be visible and editable in the Unity Inspector

}
