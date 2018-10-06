using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : Field
{
    public void BlocksToQueue()
    {
        foreach(Cell c in cells)
        {
            GameCanvas.Instance.QueueField.PutBlockInQueue(c.AttachedBlock);
        }
    }
}
