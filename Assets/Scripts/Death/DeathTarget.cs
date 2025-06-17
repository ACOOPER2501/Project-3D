using UnityEngine;

public class DeathTarget : Death
{

    public int pointsToAward;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.RegisterTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        GameManager.Instance.UnregisterTarget();

        GameManager.Instance.AwardPoints(pointsToAward);

        Destroy(gameObject); // Destroy the game object this script is attached to
    }
}
