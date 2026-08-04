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

    [SerializeField] private Sprite bottomRabbit;
    [SerializeField] private Sprite topRabbit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the relevant components 

        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (bottomRabbit != null)
        {
            spriteRenderer.sprite = bottomRabbit;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (topRabbit != null) spriteRenderer.sprite = topRabbit;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (topRabbit != null) spriteRenderer.sprite = topRabbit;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (bottomRabbit != null) spriteRenderer.sprite = bottomRabbit;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (bottomRabbit != null) spriteRenderer.sprite = bottomRabbit;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
