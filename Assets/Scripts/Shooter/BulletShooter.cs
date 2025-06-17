using UnityEngine;

public class BulletShooter : Shooter
{

    public Transform firepointTransform; // Reference to the firepoint transform where bullets will be instantiated

    public GameObject bullet; // Reference to the bullet prefab to be instantiated when shooting

    public float fireForce;

    public AudioSource shootAudioSource; // Audio source to play the shooting sound

    public AudioClip shootAudioClip; // Audio clip to be played when shooting

    public void Start()
    {
        shootAudioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }
    
    public override void Shoot()
    {
        if (shootAudioSource != null && shootAudioClip) //Note: && means both conditions must be true
        {
            shootAudioSource.PlayOneShot(shootAudioClip);
        }
        
        // Instantiate the bullet at the firepoint position and rotation
       GameObject bulletInstance = Instantiate(bullet, firepointTransform.position, firepointTransform.rotation);

       if (bulletInstance != null)
       {
           Rigidbody rb2 = bulletInstance.GetComponent<Rigidbody>(); // Get the Rigidbody2D component from the instantiated bullet

           if (rb2 != null)
           {
               rb2.AddForce(firepointTransform.forward * fireForce); // Apply an impulse force to the bullet in the direction of the firepoint's up vector
           }
           else
           {
               Debug.LogError("Bullet prefab does not have a Rigidbody component attached.");
           }
       }
   }
}
