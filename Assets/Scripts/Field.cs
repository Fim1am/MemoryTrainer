using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour {

    [SerializeField]
    private Cell cell_Prefab;

    protected List<Cell> cells = new List<Cell>();

    protected float distanceToPut = 25f;

    private void Start()
    {
        InitField();
    }

    protected void InitField()
    {
        int cellsCount = (int)FindObjectOfType<GameManager>().CurrentGameMode;

        GridLayoutGroup glg = GetComponent<GridLayoutGroup>();
        glg.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        glg.constraintCount = (int)Mathf.Sqrt(cellsCount);

        cells.Clear();

        for (int i = 0; i < cellsCount; i++)
        {
            cells.Add(Instantiate(cell_Prefab, transform, false) as Cell);
        }
    }


}
