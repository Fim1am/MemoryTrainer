using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : Cell
{
    public NumberBlock block_Prefab;

    private int originalNumber;
	
	private void Start ()
    {
        AttachedBlock = Instantiate(block_Prefab, transform, false) as NumberBlock;
	}

    public bool HaveValidNumber()
    {
        return AttachedBlock.BlockNum == originalNumber;
    }

    public void SetOriginalNumber(int _num)
    {
        originalNumber = _num;
    }
}
