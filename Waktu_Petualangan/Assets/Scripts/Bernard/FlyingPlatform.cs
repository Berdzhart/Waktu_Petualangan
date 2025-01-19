using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] public float platformVelocity;
    [SerializeField] private Rigidbody2D playerRb;
    private Rigidbody2D rb;
    private float leftEdge;
    private float rightEdge;
    private bool playerOnTop;
    private bool movingLeft = true;
    private Vector2 playerVelocity;
    private GameObject player;

    private void Awake()
    {
        leftEdge = transform.position.x;
        rightEdge = transform.position.x + movementDistance;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move platform left or right
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                rb.velocity = new Vector2(-platformVelocity, rb.velocity.y);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                rb.velocity = new Vector2(platformVelocity, rb.velocity.y);
            }
            else
            {
                movingLeft = true;
            }
        }

        // Pass platform velocity to the player if they are on the platform
        if (player != null)
        {
            player.GetComponent<PlayerMovement>().SetPlatformVelocity(rb.velocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject; // Cache the player reference
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Clear platform velocity when the player leaves the platform
            other.gameObject.GetComponent<PlayerMovement>().ClearPlatformVelocity();
            player = null; // Clear the player reference
        }
    }

    // private void Awake()
    // {
    //     leftEdge = transform.position.x;
    //     rightEdge = transform.position.x + movementDistance;
    //     rb = GetComponent<Rigidbody2D>();
    // }

    // private void Update()
    // {
    //     if (movingLeft)
    //     {
    //         if (transform.position.x > leftEdge)
    //         {
    //             rb.velocity = new Vector2(-platformVelocity, rb.velocity.y);
    //             if (playerOnTop)
    //             {
    //                 playerVelocity = playerRb.GetComponent<Rigidbody2D>().velocity;
    //                 playerVelocity = new Vector2(rb.velocity.x - platformVelocity, rb.velocity.y);
    //                 playerRb.GetComponent<Rigidbody2D>().velocity = playerVelocity;
    //             }
    //         }
    //         else if (transform.position.x <= leftEdge)
    //         {
    //             movingLeft = false;
    //         }
    //     }
    //     else if (!movingLeft)
    //     {
    //         if (transform.position.x < rightEdge)
    //         {
    //             rb.velocity = new Vector2(platformVelocity, rb.velocity.y);
    //             if (playerOnTop)
    //             {
    //                 playerVelocity = playerRb.GetComponent<Rigidbody2D>().velocity;
    //                 playerVelocity = new Vector2(rb.velocity.x + platformVelocity, rb.velocity.y);
    //                 playerRb.GetComponent<Rigidbody2D>().velocity = playerVelocity;
    //             }
    //         }
    //         else if (transform.position.x >= rightEdge)
    //         {
    //             movingLeft = true;
    //         }
    //     }
    // }

    //  private void OnCollisionEnter2D(Collision2D other)
    //  {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         playerOnTop = true;
    //     }
    //  }

    //  private void OnCollisionExit2D(Collision2D other)
    //  {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         playerOnTop = false;
    //     }
    //  }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         playerOnTop = true;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     // Check if the object collided with is a moving platform
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         playerOnTop = false;
    //     }
    // }
}
