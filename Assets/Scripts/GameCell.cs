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

        originalNumber = AttachedBlock.BlockNum;

        Transform blockTransform = AttachedBlock.transform;

        blockTransform.localPosition = Vector3.zero;
	}

    public bool HaveValidNumber()
    {

        return AttachedBlock.BlockNum == originalNumber;

    }
}
