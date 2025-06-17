using UnityEngine;

public class DeathDestroy : Death // Inherits from the abstract Death class, which defines the Die method to be implemented
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
        // Destroy the game object this script is attached to
        Destroy(gameObject);
        
    }
}
