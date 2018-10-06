using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameField : Field
{
    public void BlocksToQueue()
    {
        foreach(Cell c in cells)
        {
            GameCanvas.Instance.QueueField.PutBlockInQueue(c.AttachedBlock);
            c.AttachedBlock = null;
        }
    }

    public Cell GetClosestCell(NumberBlock _block)
    {
        float minDistance = cells.Min(c => (c.transform.position - _block.transform.position).magnitude);

        if (minDistance > distanceToPut)
            return null;

        Cell closestCell = cells.Find(c => (c.transform.position - _block.transform.position).magnitude == minDistance);

        return closestCell;

    }
}
