using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static System.Action<GameMode> OnGameModeChanged;

    public enum GameMode
    {
        ThreeGame = 9,
        FourGame = 16,
        FiveGame = 25
    }

    private GameMode currentGameMode;

    public GameMode CurrentGameMode
    { get
        {
            return currentGameMode;
        }

        private set
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


}

