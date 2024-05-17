using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    //Movement
    [SerializeField] private float thrustForce; // Adjust this value for desired movement speed
    [SerializeField] private float rotationSpeed; // Adjust for turning speed
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float nextBoostTime; // Time when the next boost becomes available
   
    //Boost force/time
    public float boostForce; // The amount of force applied during the boost
    public float boostDuration; // The duration in seconds for which the boost applies
    public float cooldownTime; // The time in seconds between boosts
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextBoostTime = Time.time + cooldownTime; // Set initial cooldown timer

      
    }


    void Update()
    {

        // Get input for horizontal and vertical movement (WASD)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate a movement vector based on input
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Apply force in the direction of the movement vector
        rb.AddForce(movement * thrustForce * Time.deltaTime);

        // Rotate the spaceship based on the direction it's facing (optional)
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90); // Adjust offset for spaceship visuals

        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextBoostTime)
        {
            // Apply boost force for the specified duration
            rb.AddForce(transform.forward * boostForce, ForceMode2D.Impulse);
            nextBoostTime = Time.time + cooldownTime;
            
        }
    
    }
}
