using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Animator playerAnimator;

    public Image[] heartImages; // assign heart UI sprites in inspector
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject gameOverScreen; // optional: assign Game Over UI here

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void LoseHeart()
    {
        if (currentHealth <= 0)
            return;

        currentHealth--;
        audioManager.PlaySFX(audioManager.loseHeart);
        UpdateHearts();

        // 🔁 Trigger damage animation
        Animator animator = GetComponent<Animator>();
        if (animator != null)
            animator.SetTrigger("TakeDamage");
           

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            if (gameOverScreen != null)
                gameOverScreen.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void GainHeart()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UpdateHearts();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
                heartImages[i].sprite = fullHeart;
            else
                heartImages[i].sprite = emptyHeart;
        }
    }

    public bool IsGameOver()
    {
        return currentHealth <= 0;
    }
}
