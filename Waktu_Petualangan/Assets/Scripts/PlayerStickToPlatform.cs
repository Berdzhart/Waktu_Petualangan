using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerStickToPlatform : MonoBehaviour
{
    private Transform originalParent;

    private void Start()
    {
        originalParent = transform.parent;
    }
    // private Rigidbody2D rb;
    // private Rigidbody2D platformRb;

    // private void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    // }

    // // private void OnTriggerEnter2D(Collider2D collision)
    // // {
    // //     // Check if the object collided with is a moving platform
    // //     if (collision.gameObject.CompareTag("Platform"))
    // //     {
    // //         platformRb = collision.gameObject.GetComponent<Rigidbody2D>();
    // //     }
    // // }

    // // private void OnTriggerExit2D(Collider2D collision)
    // // {
    // //     // Stop sticking to the platform when exiting
    // //     if (collision.gameObject.CompareTag("Platform"))
    // //     {
    // //         platformRb = null;
    // //     }
    // // }

    // // private void Update()
    // // {
    // //     // If the player is on a platform, add the platform's velocity
    // //     if (platformRb != null)
    // //     {
    // //         Vector2 platformVelocity = platformRb.velocity;
    // //         rb.velocity = new Vector2(rb.velocity.x + platformVelocity.x, rb.velocity.y);
    // //     }
    // // }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Platform"))
    //     {
    //         transform.parent = collision.transform;
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Platform"))
    //     {
    //         transform.parent = null;
    //     }
    // }

    public void SetParent(Transform newParent)
     {
        originalParent = transform.parent;
        transform.parent = newParent;
     }

     public void ResetParent()
     {
        transform.parent = originalParent;
     }
}