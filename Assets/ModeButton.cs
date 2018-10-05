using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButton : MonoBehaviour
{
    public GameManager.GameMode buttonMode;

    public void SetMode()
    {
        FindObjectOfType<GameManager>().CurrentGameMode = buttonMode;
    }
}
