using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : MonoBehaviour
{
    public NumberBlock block_Prefab;

    public NumberBlock AttachedBlock;

    private int originalNumber, supposedNumber;
	
	private void Start ()
    {
        AttachedBlock = Instantiate(block_Prefab, transform, false) as NumberBlock;

        originalNumber = AttachedBlock.BlockNum;

        Transform blockTransform = AttachedBlock.transform;

        blockTransform.localPosition = Vector3.zero;
	}

    public bool HaveValidNumber()
    {

        return originalNumber == supposedNumber;

    }
}
