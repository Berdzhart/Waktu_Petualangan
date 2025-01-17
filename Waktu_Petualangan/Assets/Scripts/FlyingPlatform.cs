using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private float leftEdge;
    private float rightEdge;
    private bool playerOnTop;

    private void Awake()
    {
        leftEdge = transform.position.x;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (!playerOnTop)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
        else if (playerOnTop)
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerOnTop = true;
        }
        else if (collision.tag == null)
        {
            playerOnTop = false;
        }
    }
}
