using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField]
    private GameCell gameCell_Prefab;

    private List<GameCell> activeCells;

    private Transform selfTransform;
	
	private void OnEnable ()
    {
        selfTransform = transform;

        ClearField();

        InitGameField();
	}
	
	private void InitGameField()
    {
        int cellsCount = (int) FindObjectOfType<GameManager>().CurrentGameMode;

        for(int i = 0; i < cellsCount; i++)
        {
            activeCells.Add(Instantiate(gameCell_Prefab, selfTransform, false) as GameCell);
        }
    }

    public void ClearField()
    {
        if (activeCells == null)
            activeCells = new List<GameCell>();
        else
            activeCells.Clear();
    }
}
