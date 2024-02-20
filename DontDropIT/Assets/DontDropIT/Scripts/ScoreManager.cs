using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public Image scoreProgressImage;
    public TMP_Text scoreText;

    public int mainScore = 0;
    public int maxScore = 100;

    void Update()
    {
        UpdateProgressBar();
    }

    public void AddScore(int score)
    {
        mainScore += score;
        mainScore = Mathf.Clamp(mainScore, 0, maxScore);
        UpdateProgressBar();

        if (mainScore == maxScore)
        {
            Debug.Log("Luggage filled!");
            // Do something when luggage is filled
        }
    }
    public void ScoreLost(int score)
    {
        mainScore -= score;
        mainScore = Mathf.Clamp(mainScore, 0, maxScore);
        UpdateProgressBar();

        if (mainScore == 0)
        {
            Debug.Log("LevelFailed");
            // Do something when luggage is filled
        }
    }
    void UpdateProgressBar()
    {
        float progress = mainScore / (float)maxScore;
        scoreProgressImage.fillAmount = progress;
        scoreText.text = (Mathf.RoundToInt(progress * 100)) + "%";
    }
}
