using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

    [SerializeField]
    private Cell cell_Prefab;

    protected List<Cell> cells = new List<Cell>();


    private void OnEnable()
    {
        InitField();
    }

    protected void InitField()
    {
        cells.Clear();

        int cellsCount = (int)FindObjectOfType<GameManager>().CurrentGameMode;

        for (int i = 0; i < cellsCount; i++)
        {
            cells.Add(Instantiate(cell_Prefab, transform, false) as Cell);
        }
    }


}
