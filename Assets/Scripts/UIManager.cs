using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionsText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject restartButton;

    float timerProgress;

    bool isStarted;
    public int matchedPairs;
    int totalPairs = 6;

    private void Awake()
    {
        isStarted = false;
    }

    void Start()
    {
        instructionsText.enabled = true;
        startButton.SetActive(true);
        restartButton.SetActive(false);

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

        if (matchedPairs == totalPairs)
        {
            isStarted = false;
            restartButton.SetActive(true);
        }
    }

    public void OnStartButton()
    {
        isStarted = true;

        instructionsText.enabled = false;
        startButton.SetActive(false);
    }
    public void OnRestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public bool GetIsStarted()
    {
        return isStarted;
    }
}
