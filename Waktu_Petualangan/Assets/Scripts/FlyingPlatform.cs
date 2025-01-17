using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] public float speed;
    private float leftEdge;
    private float rightEdge;

    private bool movingLeft = true;

    private void Awake()
    {
        leftEdge = transform.position.x;
        rightEdge = transform.position.x + movementDistance;
    }

    private void FixedUpdate()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (transform.position.x <= leftEdge)
            {
                movingLeft = false;
            }
        }
        else if (!movingLeft)
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (transform.position.x >= rightEdge)
            {
                movingLeft = true;
            }
        }
    }

     private void OnCollisionEnter2D(Collision2D other)
     {
        var platformMovement = other.collider.GetComponent<PlayerStickToPlatform>();

        if (platformMovement != null)
        {
            platformMovement.SetParent(transform);
       
        }
     }

     private void OnCollisionExit2D(Collision2D other)
     {
        var platformMovement = other.collider.GetComponent<PlayerStickToPlatform>();
        var playerSpeed = other.collider.GetComponent<PlayerMovement>().speed;
        if (platformMovement != null)
        {
            platformMovement.ResetParent();

        }
     }

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
