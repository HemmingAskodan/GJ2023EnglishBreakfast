using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText;
    public float countdownTime = 300.0f; // 300 seconds (5 minutes)
    private float currentTime;

    private void Start()
    {
        currentTime = countdownTime;
    }

    private void Update()
    {
        // Update the timer
        currentTime -= Time.deltaTime;

        // Ensure the timer doesn't go negative
        currentTime = Mathf.Max(currentTime, 0.0f);

        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Display the timer in "MM:SS" format
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Check if the timer has reached zero
        if (currentTime <= 0.0f)
        {
            // Call function that stops the game or performs other actions
        }
    }


    // public float CountdownTest(float totalSeconds, float timeLimit)
    // {
    //     totalSeconds = 300f;
    //     timeLimit = totalSeconds / 5;
    //     return timeLimit;
    // }
}
