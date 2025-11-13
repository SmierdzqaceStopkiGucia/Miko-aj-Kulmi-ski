using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject[] players;

    private bool roundEnded = false;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
         players = GameObject.FindGameObjectsWithTag("Player1")
        .Concat(GameObject.FindGameObjectsWithTag("Player2"))
        .ToArray();
    }

public void CheckWinState()
    {
        if (roundEnded)
            return;

        int aliveCount = 0;
        GameObject lastAlive = null;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].activeSelf)
            {
                aliveCount++;
                lastAlive = players[i]; 
            }
        }


        if (aliveCount <= 1)
        {
            roundEnded = true;

            if (lastAlive != null)
            {
                if (lastAlive.CompareTag("Player1"))
                    ScoreManager.instance.AddPoint1();
                else if (lastAlive.CompareTag("Player2"))
                    ScoreManager.instance.AddPoint2();
            }

            Invoke(nameof(NewRound), 3f);
        }
    }

    private void NewRound()
    {
        roundEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
