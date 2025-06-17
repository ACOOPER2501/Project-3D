using UnityEngine;

public class PlayerPawn : MonoBehaviour
{

    private Transform tf; // A private variable to hold the Transform component of the player ship / pawn

    public Shooter shooter; // A reference to the Shooter script, which handles shooting functionality

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        tf = transform;

        shooter = GetComponent<Shooter>(); // Get the Shooter component attached to this GameObject

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (shooter != null) // Check if the shooter reference is assigned in the Inspector
        {
            shooter.Shoot(); // Call the Shoot method from the Shooter script to handle shooting functionality
        }
    }

    public void PrintHello()
    {
       // Debug.Log("Hello from PlayerPawn!");
    }
}
