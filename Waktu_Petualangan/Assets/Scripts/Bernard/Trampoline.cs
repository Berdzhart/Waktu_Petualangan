using Unity.Burst.Intrinsics;
using UnityEditor.Callbacks;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float trampolinePower;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, trampolinePower);
            animator.SetTrigger("PlayerOnTop");
            Invoke("TrampolineIdle", 0.4f);
        }
    }
    private void TrampolineIdle()
    {
        animator.SetTrigger("PlayerNotOnTop"); 
    }
}
