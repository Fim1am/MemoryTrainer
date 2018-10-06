using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBlock : MonoBehaviour
{
    [SerializeField]
    private int maxNum = 100;

    public int BlockNum { get; set; }

    private Cell gameCell;
    
	
	private void Start ()
    {
        BlockNum = Random.Range(1, maxNum);

        GetComponentInChildren<UnityEngine.UI.Text>().text = BlockNum.ToString();
	}

    private void Update()   
    {
        
    }

    public void AttachToCell(Cell _cell)
    {
        transform.parent = _cell.transform;
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
    }

}
