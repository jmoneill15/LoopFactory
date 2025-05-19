using UnityEngine;
using UnityEngine.UI; // Needed for UI

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float sprintSpeed = 7f;
    public KeyCode sprintKey = KeyCode.LeftShift;

    public float maxStamina = 5f; // in seconds
    public float staminaDrainRate = 1f;
    public float staminaRegenRate = 0.5f;
    public float sprintThreshold = 0.2f;

    public Slider staminaBar; // Drag your UI Slider here in the Inspector
    public Image staminaFillImage;

    private float currentStamina;
    private bool isSprinting;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float currentSpeed;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentStamina = maxStamina;

        if (staminaBar != null)
            staminaBar.maxValue = maxStamina;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Flip sprite
        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else if (movement.x > 0)
            spriteRenderer.flipX = false;

        // Sprint logic
        isSprinting = Input.GetKey(sprintKey) && currentStamina > 0 && movement != Vector2.zero;

        // Sprint only if enough stamina
        bool wantsToSprint = Input.GetKey(sprintKey) && movement != Vector2.zero;
        bool canSprint = currentStamina > sprintThreshold;

        if (wantsToSprint && canSprint)
        {
            isSprinting = true;
            currentSpeed = sprintSpeed;
            currentStamina -= staminaDrainRate * Time.deltaTime;
            if (currentStamina < 0) currentStamina = 0;
        }
        else
        {
            isSprinting = false;
            currentSpeed = moveSpeed;

            // Only regen if not trying to sprint
            if (!wantsToSprint)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                if (currentStamina > maxStamina) currentStamina = maxStamina;
            }
        }
        // this what drains the slider
        if (staminaBar != null)
            staminaBar.value = currentStamina;

        if (staminaFillImage != null)
        {
            if (currentStamina <= 0.5f)
                staminaFillImage.color = Color.red;
            else if (currentStamina < maxStamina * 0.10f)
                staminaFillImage.color = new Color(1f, 0.64f, 0f); // orange
            else
                staminaFillImage.color = Color.green;
        }



    }
    public void BoostStamina(float amount)
    {
        currentStamina += amount;
        if (currentStamina > maxStamina)
            currentStamina = maxStamina;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * currentSpeed * Time.fixedDeltaTime);
    }
}