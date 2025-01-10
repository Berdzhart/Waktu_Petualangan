using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator animator;
    private bool dead;
    public float hitTime = 1f;
    public float hitTimeCounter = 0f;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();


    }

    void Update()
    {
        
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            
            hitTimeCounter = hitTime;
            
            //iframes
        }
        else
        {
            if (!dead)
            {
                animator.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}