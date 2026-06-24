using UnityEngine;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionsText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject startButton;

    float timerProgress;

    bool isStarted;

    private void Awake()
    {
        isStarted = false;
    }

    void Start()
    {
        instructionsText.enabled = true;
        startButton.SetActive(true);

        timerProgress = 0f;
    }

    void Update()
    {
        if (isStarted)
        {
            timerProgress += Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(timerProgress);
        timerText.text = "Time: " + time.Seconds.ToString() + "." + time.Milliseconds.ToString();
    }

    public void OnStartButton()
    {
        isStarted = true;

        instructionsText.enabled = false;
        startButton.SetActive(false);
    }
    public bool GetIsStarted()
    {
        return isStarted;
    }
}
