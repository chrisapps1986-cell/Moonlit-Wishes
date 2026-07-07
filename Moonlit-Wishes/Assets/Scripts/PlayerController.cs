using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    // Initialising References
    BoxCollider2D bc2d;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the relevant components 

        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Get the horizontal input for the player movement and store it in a variable
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        // if statement to face sprite to the left
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Debug.Log("Sprite has rotated left");
        }

        // else, face sprite to the right
        else if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Debug.Log("Sprite has rotated right");
        }  
    }
}
