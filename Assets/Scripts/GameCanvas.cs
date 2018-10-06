using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas Instance { get; set; }

    public GameField GameField;
    public QueueField QueueField;

    [SerializeField]
    private Image timer_Image;

    private float timeToRemember;

    private void Awake()
    {
        Instance = this;
        timeToRemember = FindObjectOfType<GameManager>().TimeToRemember;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        float t = timeToRemember;

        while(t > 0)
        {
            t -= Time.deltaTime;

            timer_Image.fillAmount = t / timeToRemember;

            yield return new WaitForEndOfFrame();
        }

        timer_Image.gameObject.SetActive(false);

        GameField.BlocksToQueue();

    }

}
