using UnityEngine;
using TMPro; // Importing TMPro for TextMeshPro support
using UnityEngine.UI; // Importing necessary UnityEngine namespaces for UI components
using UnityEngine.SceneManagement; // Importing UnityEngine.SceneManagement for scene management
using System.Collections;
using System.Collections.Generic; // Importing necessary namespaces for collections
using Unity.VisualScripting;
using UnityEngine.Events; // Importing TMPro for TextMeshPro support

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text scoreText;

    public TMP_Text remainingText;

    public int targetCount = 0;

    public int score = 0; // Initialize score to 0

    public int startingLives = 3; // Starting lives for the player

    public int currentLives; // Current lives of the player

    public GameObject gameOverText; // Reference to the Game Over text object

    public GameObject victoryText; // Reference to the Victory text object

    public GameObject playerShip; // Reference to the player prefab

    public Transform respawnPoint; // Reference to the respawn point for the player



    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set the singleton instance
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }

    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLives = startingLives; // Initialize current lives to starting lives
        if (gameOverText != null)
        {
            gameOverText.SetActive(false); // Ensure Game Over text is inactive at the start
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterTarget()
    {
        targetCount++; // Increment the target count when a target is registered

        if (remainingText != null)
        {
            remainingText.text = "Remaining: " + targetCount; // Update the remaining targets text
        }
    }

    public void UnregisterTarget()
    {
        targetCount--;

        if (remainingText != null)
        {
            remainingText.text = "Remaining: " + targetCount; // Update the remaining targets text
        }

        if (targetCount < 0) targetCount = 0;
        {
            //victoryText.SetActive(true); // Activate the Victory text when all targets are cleared
        }
        
    }

    private bool gameEnded = false;

    public void PlayerDied()
    {
        if (!gameEnded)
        {
            Debug.Log("Failure");
            gameEnded = true;

            gameOverText.SetActive(true); // Activate the Game Over text
        }
    }

    public void CheckVictory()
    {
        if (targetCount <= 0 && !gameEnded)
        {
            Debug.Log("Victory");
            gameEnded = true;
        }
    }

    public void AwardPoints(int pointsAwarded)
    {
        score += pointsAwarded; // Increment the score by the awarded points
        // score = score + pointsAwarded; is an alternative way to increment the score

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the score text
        }
    }

    public void ResetGame()
    {
        score = 0; // Reset the score to 0
        targetCount = 0; // Reset the target count to 0
        currentLives = startingLives; // Reset current lives to starting lives
        gameEnded = false; // Reset game ended state
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the score text
        }
        if (remainingText != null)
        {
            remainingText.text = "Remaining: " + targetCount; // Update the remaining targets text
        }
        if (gameOverText != null)
        {
            gameOverText.SetActive(false); // Deactivate the Game Over text
        }
    }

    public void RespawnPlayer() // Method to respawn the player ship at the respawn point
    {
        if (playerShip != null && respawnPoint != null) // Check if playerShip and respawnPoint are assigned
        {
            playerShip.transform.position = respawnPoint.position; // Set the player ship's position to the respawn point
            playerShip.SetActive(true); // Activate the player ship

            // Reset movement momentum
            Rigidbody2D rb = playerShip.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component from the player ship
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }

            PlayerHealth ph = playerShip.GetComponent<PlayerHealth>(); // Get the PlayerHealth component from the player ship
            if (ph != null)
            {
                ph.Heal(ph.maxHealth); // Heal the player ship to its maximum health
            }
        }
    }

}
