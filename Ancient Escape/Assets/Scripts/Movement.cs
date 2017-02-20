using UnityEngine;
using System.Collections;
using System;

public class Movement : MonoBehaviour {

    public bool canMoveVertical;
    public bool canMoveHorizontal;
    public float width;
    public float height;
    private Vector3 screenPoint;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
	}

    void Update()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        var yInput = Input.GetAxis("Mouse Y");
        var xInput = Input.GetAxis("Mouse X");
        var movingHorizontal = true;
        var movingVertical = true;
        Vector3 raycastDirection;
        float castDistance = 0;
        // Decide if the block is trying to move up and down or left and right.
        if (Math.Abs(yInput) > Math.Abs(xInput))
        {
            movingHorizontal = false;
            castDistance = height / 2;

            if (yInput > 0)
                raycastDirection = Vector3.up;
            else
                raycastDirection = Vector3.down;
        }
        else
        {
            movingVertical = false;
            castDistance = width / 2;
            if (xInput > 0)
                raycastDirection = Vector3.right;
            else
                raycastDirection = Vector3.left;
        }

        // Block movement in directions a block should not go
        //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (!canMoveHorizontal || !movingHorizontal)
        {
            curPosition = new Vector3(gameObject.transform.position.x, curPosition.y, curPosition.z);
        }
        if (!canMoveVertical || !movingVertical)
        {
            curPosition = new Vector3(curPosition.x, gameObject.transform.position.y, curPosition.z);
        }
        
        //Is a block about to hit another block?
        var hits = Physics2D.RaycastAll(gameObject.transform.position, raycastDirection, castDistance);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit && hit.transform.gameObject != gameObject)
            {
                return;
            }
        }

        // Update position
        transform.position = curPosition;
    }
}
