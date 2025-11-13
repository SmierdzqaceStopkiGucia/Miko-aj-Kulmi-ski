using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText1;
    public Text scoreText2;

    int score1 = 0;
    int score2 = 0;

    private void Awake()
    {
        // Make this object persist between scene loads
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText1 != null)
            scoreText1.text = score1 + " POINTS";

        if (scoreText2 != null)
            scoreText2.text = score2 + " POINTS";
    }

    public void AddPoint1()
    {
        score1++;
        UpdateUI();
    }

    public void AddPoint2()
    {
        score2++;
        UpdateUI();
    }

    public void ReconnectUI(Text newScoreText1, Text newScoreText2)
    {
        scoreText1 = newScoreText1;
        scoreText2 = newScoreText2;
        UpdateUI();
    }
}
