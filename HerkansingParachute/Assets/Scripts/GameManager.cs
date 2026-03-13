using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _score; 

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

    public void AddPoint()
    {
        _score++;
    }

    public void RemovePoint()
    {
        _score--;
    }

    public int GetScore()
    {
        return _score;
    }
}
