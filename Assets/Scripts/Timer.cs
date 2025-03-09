using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int milliseconds = (int)((elapsedTime - (int)elapsedTime) * 1000);
        int minutes = (int)elapsedTime / 60;
        int seconds = (int)elapsedTime % 60;
        
        // Divide by 10 to get a two-digit value (0-99)
        int twoDigitMilliseconds = milliseconds / 10;
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, twoDigitMilliseconds);
    }

}
