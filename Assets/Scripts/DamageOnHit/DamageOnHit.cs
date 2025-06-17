using UnityEngine;

public class DamageOnHit : MonoBehaviour
{

    public float damageAmount;

    public bool destroySelf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        PlayerHealth otherHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageAmount); // Apply damage

        }

        if (destroySelf)
        {
            Destroy(gameObject); // Destroy bullet on hit if destroySelf is true
        }
    }
}
