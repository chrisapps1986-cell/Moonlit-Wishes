using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float spinSpeed = 200f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = spinSpeed;
    }
}