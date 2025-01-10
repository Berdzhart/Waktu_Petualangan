using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 2f;
    public float horizontal;
    public float jumpingPower = 4f;
    public bool isFacingRight = true;
    public bool isGrounded;

    public bool isWallClinging;
    public bool isWallTouching;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(2f, 4f);

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("VerticalSpeed", rb.velocity.y);
        animator.SetBool("IsWallClinging", isWallTouching);
        animator.SetBool("IsGrounded", isGrounded);
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.15f, 0.03f), 0, groundLayer);
        isWallTouching = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.02f, 0.2f), 0, wallLayer);
        // WallSlide();
        WallCling();
        WallJump();
        Flip();
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontal));
        
    }

    // private void WallSlide()
    // {
    //     if (isWallTouching && horizontal != 0f && !isGrounded)
    //     {
    //         isWallSliding = true;
    //         rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
    //     }
    //     else
    //     {
    //         isWallSliding = false;
    //     }
    // }

    private void WallCling()
    {
        if (isWallTouching && horizontal != 0f && !isGrounded)
        {
            isWallClinging = true;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0);
        }
        else
        {
            isWallClinging = false;
        }
    }

    private void WallJump()
    {
        if (isWallClinging)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
     }
}
