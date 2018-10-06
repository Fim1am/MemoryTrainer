using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueField : Field
{

    public void PutBlockInQueue(NumberBlock _block)
    {
        List<Cell> emptyCells = cells.FindAll(c => c.IsEmpty());

        _block.AttachToCell(emptyCells[Random.Range(0, emptyCells.Count)]);
    }
}
