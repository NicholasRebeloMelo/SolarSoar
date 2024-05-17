using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundary : MonoBehaviour
{
    public float topBoundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player's current position
        Vector3 playerPosition = transform.position;

        // Check if player is above the top boundary
        if (playerPosition.y > topBoundary)
        {
            // Clamp y position to top boundary
            playerPosition.y = topBoundary;
        }

        // Update player's position
        transform.position = playerPosition;
    }
}
