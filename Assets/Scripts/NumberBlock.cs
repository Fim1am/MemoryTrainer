using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberBlock : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public static System.Action OnBlockAttached;

    [SerializeField]
    private int maxNum = 100;

    public int BlockNum { get; set; }

    private Cell cell;

    private bool isHolded;
    
    private Vector2 draggingScale = Vector2.one * 2f;

    private float lerpTransition = 8f;

    private Transform selfTransform;
	
	private void Start ()
    {
        selfTransform = transform;

        selfTransform.localPosition = Vector2.zero;

        cell = selfTransform.parent.GetComponent<Cell>();

        BlockNum = Random.Range(1, maxNum);

        (cell as GameCell).SetOriginalNumber(BlockNum);

        GetComponentInChildren<UnityEngine.UI.Text>().text = BlockNum.ToString();
	}

    private void Update()   
    {
        if(isHolded)
        {
            selfTransform.position = Input.mousePosition;
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
        cell.AttachedBlock = null;

        transform.SetParent(_cell.transform);
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;

        if(!_cell.IsEmpty())
        {
            GameCanvas.Instance.QueueField.PutBlockInQueue(_cell.AttachedBlock);
        }

        cell = _cell;
        cell.AttachedBlock = this;

        OnBlockAttached?.Invoke();
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
            transform.SetParent(cell.transform);
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
