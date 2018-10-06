using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static System.Action<GameMode> OnGameModeChanged;

    [SerializeField]
    private GameCanvas gameCanvas_Prefab;

    private GameCanvas currentGame;

    public float TimeToRemember { get; private set; }

    public enum GameMode
    {
        ThreeGame = 9, // this mode contains 9 blocks on a game field etc.
        FourGame = 16,
        FiveGame = 25
    }

    private GameMode currentGameMode = GameMode.ThreeGame;

    public GameMode CurrentGameMode
    {
        get
        {
            return currentGameMode;
        }

         set
        {
            currentGameMode = value;
            OnGameModeChanged?.Invoke(currentGameMode);
        }
    }

	
	void Start ()
    {
        SetThreeGameMode();
	}

    public void SetThreeGameMode()
    {
        CurrentGameMode = GameMode.ThreeGame;
    }

    public void SetFourGameMode()
    {
        CurrentGameMode = GameMode.FourGame;
    }

    public void SetFiveGameMode()
    {
        CurrentGameMode = GameMode.FiveGame;
    }

    public void StartGame()
    {
        currentGame = Instantiate(gameCanvas_Prefab, gameCanvas_Prefab.transform.position, Quaternion.identity);
    }

    public void TimeChanged(float _time)
    {
        TimeToRemember = _time;
    }

}

