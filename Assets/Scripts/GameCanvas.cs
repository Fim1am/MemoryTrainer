using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas Instance { get; set; }

    public GameField GameField;
    public QueueField QueueField;

    private void Awake()
    {
        Instance = this;
    }

}
