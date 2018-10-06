using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public NumberBlock AttachedBlock;

    public bool IsEmpty()
    {
        return AttachedBlock == null;
    }
    
}
