using UnityEngine;
using TMPro;
using System.Collections;

public class HelperBotThinking : MonoBehaviour
{
    public GameObject thinkingCloudPanel;
    public TextMeshProUGUI cloudText;

    private Coroutine hideRoutine;
    

    public void ShowThoughtLong(string message, float duration = 6f)
    {
        if (hideRoutine != null)
            StopCoroutine(hideRoutine);

        cloudText.text = message;
        thinkingCloudPanel.SetActive(true);
        hideRoutine = StartCoroutine(HideAfterDelay(duration));
    }

        public void ShowThoughtLonger(string message, float duration = 10f)
    {
        if (hideRoutine != null)
            StopCoroutine(hideRoutine);

        cloudText.text = message;
        thinkingCloudPanel.SetActive(true);
        hideRoutine = StartCoroutine(HideAfterDelay(duration));
    }

    

    private IEnumerator HideAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        thinkingCloudPanel.SetActive(false);
    }
}
