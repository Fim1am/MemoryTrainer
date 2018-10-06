using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    [SerializeField]
    private ModeButton[] modeButtons;

    [SerializeField]
    private Slider time_Slider;

    [SerializeField]
    private Text time_text;

	void OnEnable ()
    {
        GameManager.OnGameModeChanged += UpdateModeButtons;

        time_Slider.onValueChanged.AddListener(SliderChanged);

        time_text.text = time_Slider.value.ToString() + " s";

        FindObjectOfType<GameManager>().TimeChanged((float)time_Slider.value);
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

    private void SliderChanged(float _val)
    {
        time_text.text = _val.ToString() + " s";
        FindObjectOfType<GameManager>().TimeChanged((float)time_Slider.value);
    }
}
