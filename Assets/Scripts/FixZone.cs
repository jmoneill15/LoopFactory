
using UnityEngine;

public class FixZone : MonoBehaviour
{
    public ProcessingZone processor;
    public float holdTime = 2f;
    private float timer = 0f;
       public LogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (processor == null || processor.canProcess)
            return;

        if (other.CompareTag("Player"))
            Debug.Log("🧪 Player is in fix zone");

        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Q))
        {
            Debug.Log("⏳ Player is holding Q...");
            timer += Time.deltaTime;
            if (timer >= holdTime)
            {
                Debug.Log("🛠️ Calling FixProcessor()");
                processor.FixProcessor(); // this MUST be called
                logic.WhileLoopFixed();
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0f;
        }
    }
}