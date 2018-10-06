using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    [SerializeField]
    private ModeButton[] modeButtons;

	void Awake ()
    {
        GameManager.OnGameModeChanged += UpdateModeButtons;
	}
	
    private void UpdateModeButtons(GameManager.GameMode _mode)
    {
        foreach(ModeButton b in modeButtons)
        {
            if(_mode == b.buttonMode)
            {
                b.GetComponent<Image>().color = Color.green;
            }
            else
            {
                b.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void StartGameButton()
    {
        FindObjectOfType<GameManager>().StartGame();
        gameObject.SetActive(false);
    }
}
