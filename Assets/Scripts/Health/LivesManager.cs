using UnityEngine;
using TMPro; // Importing TMPro for TextMeshPro support
using UnityEngine.UI; // Importing necessary UnityEngine namespaces for UI components
using UnityEngine.SceneManagement; // Importing UnityEngine.SceneManagement for scene management
using System.Collections;
using System.Collections.Generic; // Importing necessary namespaces for collections
using Unity.VisualScripting;
using UnityEngine.Events; // Importing TMPro for TextMeshPro support
public class LivesManager : MonoBehaviour // Inherits from GameManager to manage player lives
{
    [SerializeField] // SerializeField allows private fields to be visible in the Unity Inspector
    private float lifeImageWidth = 113f; // Width of the live image, set to 113 by default

    [SerializeField]
    private int maxLives = 3; // Maximum number of lives, set to 3 by default

    [SerializeField]
    private int numOfLives = 3; // Number of lives currently held, initialized to 3

    private RectTransform rect;

    public UnityEvent OutOfLives; // UnityEvent to be invoked when the player runs out of lives

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        rect = transform as RectTransform; // Get the RectTransform component of this GameObject

        AdjustImageWidth();
    }

    public int NumOfLives
    {
        get => numOfLives; // Getter for the number of lives
        private set
        {
            numOfLives = Mathf.Clamp(value, min: 0, max: numOfLives);
            AdjustImageWidth();
        }
    }

    public void AddLife(int num = 1)
    {
        NumOfLives += num; // Increment the number of lives by the specified amount
        if (NumOfLives > maxLives) NumOfLives = maxLives; // Ensure the number of lives does not exceed the maximum
        Debug.Log("Lives: " + NumOfLives); // Log the current number of lives
    }

    public void RemoveLife(int num = 1)
    {
        NumOfLives -= num; // Decrement the number of lives by the specified amount
        if (NumOfLives < 0) NumOfLives = 0; // Ensure the number of lives does not go below zero
        Debug.Log("Lives: " + NumOfLives); // Log the current number of lives

        if (NumOfLives <= 0)
        {
            GameManager.Instance.PlayerDied(); // Call PlayerDied if lives reach zero
        }
        else
        {
            GameManager.Instance.RespawnPlayer(); // Call RespawnPlayer to respawn the player
            //Change TextMeshPro text to show remaining lives
            //Debug.Log("Lives remaining: " + currentLives); // Log remaining lives
        }
    }

    private void AdjustImageWidth()
    {
        rect.sizeDelta = new Vector2(x: lifeImageWidth * numOfLives, rect.sizeDelta.y); // Update the size of the RectTransform based on the number of lives
    }
}
