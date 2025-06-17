using UnityEngine;

public abstract class Death : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Note to self: This class is abstract, meaning it cannot be instantiated directly.
    //using abstract classes allows us to define methods that must be implemented by any derived class.
    public abstract void Die(); // Abstract method to be implemented by derived classes for handling death logic
}
