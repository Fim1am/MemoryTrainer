using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBlock : MonoBehaviour
{
    [SerializeField]
    private int maxNum = 100;

    public int BlockNum { get; set; }

	
	void Start ()
    {
        BlockNum = Random.Range(1, maxNum);

        GetComponentInChildren<UnityEngine.UI.Text>().text = BlockNum.ToString();
	}
	

}
