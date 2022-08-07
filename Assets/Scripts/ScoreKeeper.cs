using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{

    int currentScore = 0;

    static ScoreKeeper instance;

    public int GetScore()
    {
        return currentScore;
    }

    public void resetScore()
    {
        currentScore = 0;
    }

    public void modifyScore(int score)
    {
        currentScore = score;
    }

    public void incrementScore(int score)
    {
        currentScore += score;
        Mathf.Clamp(score, 0, int.MaxValue);
    }

    private void Awake()
    {
        ManageSingleton();
    }
    private void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
