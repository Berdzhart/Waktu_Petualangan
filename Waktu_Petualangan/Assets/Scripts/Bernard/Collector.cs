using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public PlayerScore playerScore;
    private float disappearTime = 0.3f;
    private float currentTime = -1f;
    public Animator animator;
    public Collider2D fruitCollider;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
        }
        else if (currentTime < 0.01f && currentTime > -0.01f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScore.scoreCount++;
            currentTime = disappearTime;
            animator.SetTrigger("Collecting");
            fruitCollider.enabled = false;
        }
    }

    private void DisableCollider()
    {
        
    }
}