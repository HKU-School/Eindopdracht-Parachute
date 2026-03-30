using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _score; 

    public event Action<int> OnScoreChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoint(int amount)
    {
        _score += amount;
        OnScoreChange?.Invoke(_score);
    }

    public void RemovePoint(int amount)
    {
        _score -= amount;
        OnScoreChange?.Invoke(_score);
    }

    public int GetScore()
    {
        return _score;
    }
}
