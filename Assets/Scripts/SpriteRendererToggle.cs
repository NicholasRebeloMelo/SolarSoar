using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererToggle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private float showTime = 0.5f; // Adjust this value to control how long the sprite is shown (in seconds)
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; // Start with the sprite disabled
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; // Toggle the sprite renderer on/off
            timer = 0f; // Reset the timer when space is pressed
        }
        else if (timer > showTime)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            timer += Time.deltaTime; // Update the timer
        }
    }
}
