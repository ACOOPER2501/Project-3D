using UnityEngine;

public class DeathMoveToOrigin : Death // Inherits from the abstract Death class, which defines the Die method to be implemented
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        gameObject.transform.position = new Vector3(0.0f, -3.0f, 0.0f); // Move the game object to the starting position of (0, -3, 0)
    }
}
