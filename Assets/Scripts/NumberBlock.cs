﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberBlock : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private int maxNum = 100;

    public int BlockNum { get; set; }

    private Cell gameCell;

    private bool isHolded, isAttached;

    private Vector3 draggingOffset = new Vector3(0, 5f, -1f);
    private Vector2 draggingScale = new Vector2(2f, 2f);

    private float lerpTransition = 8f;

    private Transform selfTransform;
	
	private void Start ()
    {
        selfTransform = transform;

        gameCell = selfTransform.parent.GetComponent<Cell>();

        BlockNum = Random.Range(1, maxNum);

        GetComponentInChildren<UnityEngine.UI.Text>().text = BlockNum.ToString();
	}

    private void Update()   
    {
        if(isHolded)
        {
            selfTransform.position = (Vector3)Input.mousePosition + draggingOffset;
            selfTransform.localScale = Vector2.Lerp(selfTransform.localScale, draggingScale, Time.deltaTime * lerpTransition);
        }
        else
        {
            
            selfTransform.localPosition = Vector2.Lerp(selfTransform.localPosition, Vector2.zero, Time.deltaTime * lerpTransition);
            selfTransform.localScale = Vector2.Lerp(selfTransform.localScale, Vector2.one, Time.deltaTime * lerpTransition);
            
        }
    }

    public void AttachToCell(Cell _cell)
    {
        transform.SetParent(_cell.transform);
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;

        if(!_cell.IsEmpty())
        {
            GameCanvas.Instance.QueueField.PutBlockInQueue(_cell.AttachedBlock);
        }

        gameCell = _cell;
        gameCell.AttachedBlock = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolded = true;
        transform.SetParent(transform.root);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolded = false;

        if(GetCellToPutOn() == null)
        {
            transform.SetParent(gameCell.transform);
        }
        else
        {
            AttachToCell(GetCellToPutOn());
        }
    }

    private Cell GetCellToPutOn()
    {
        return GameCanvas.Instance.GameField.GetClosestCell(this);
    }

}
