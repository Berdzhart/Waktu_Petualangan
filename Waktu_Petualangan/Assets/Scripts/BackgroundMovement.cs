using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float backgroundSpeed;
    public Rigidbody2D rb;
    void Awake()
    {
        rb.velocity = new Vector2(0, backgroundSpeed);
    }
}
