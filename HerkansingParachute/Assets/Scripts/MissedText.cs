using UnityEngine;
using System.Collections;
using TMPro;
public class MissedText : MonoBehaviour
{
    [Header("UI and duration")]
    [SerializeField] private GameObject text;
    [SerializeField] private float popUpTime;

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

    // Show text for short duration
    private IEnumerator MissedPopUp()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(popUpTime);
        text.SetActive(false);
    }
}
