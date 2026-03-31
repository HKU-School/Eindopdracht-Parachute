using UnityEngine;
using System.Collections;
using TMPro;
public class MissedText : MonoBehaviour
{
    [SerializeField] private float popUpTime;
    [SerializeField] private GameObject text;

    private void Start()
    {
        if (GameManager.instance == null)
        {
            Debug.LogError("Gamemanager is null aaaa");
        }
        else
        {
            GameManager.instance.OnParachutMissed += ShowText;
        }
    }

    private void OnEnable()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnParachutMissed += ShowText;
        }
    }

    private void OnDisable()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnParachutMissed -= ShowText;
        }
    }

    public void ShowText()
    {
        StartCoroutine(MissedPopUp());
    }

    private IEnumerator MissedPopUp()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(popUpTime);
        text.SetActive(false);
    }
}
