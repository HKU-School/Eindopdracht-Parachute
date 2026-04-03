using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _score;

    private int _caughtCount = 0;

    public event Action<int> OnScoreChange;
    public event Action OnParachutMissed;
    public event Action<int> OnLivesChanged;
    public event Action OnGameOver;

    [Header("Player lives")]
    [SerializeField] private int maxLives;
    private int _currentLives;

    // Only 1 game manager can exist
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

        _currentLives = maxLives;
    }

    // Manage player score
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

    // Called when parachute is missed 
    public void ParachutMissed()
    {
        OnParachutMissed?.Invoke();
    }

    // Called when player is damaged 
    public void TakeDamage(int amount = 1)
    {
        _currentLives -= amount;
        OnLivesChanged?.Invoke(_currentLives);

        if (_currentLives <= 0)
        {
            GameOver();
        }
    }

    // Lives 
    public int GetLives()
    {
        return _currentLives;
    }

    public void CatCaught(int amount)
    {
        _caughtCount++;
        if (_caughtCount > maxLives)
        {
            GiveLife(1);
            _caughtCount = 0;
        }
    }

    public void GiveLife(int amount)
    {
        _currentLives += amount;
        if (_currentLives > maxLives)
        {
            _currentLives = maxLives;
        }

        OnLivesChanged?.Invoke(_currentLives);
    }

    // When triggered notifies all subs
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
