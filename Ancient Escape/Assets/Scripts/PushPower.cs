using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PushPower : MonoBehaviour {

    public int numberCastable;
    public float radius;
    public float distance;
    public Text castableButton;

    void Start ()
    {
        if (castableButton != null)
            castableButton.text = numberCastable.ToString();
    }

    private bool open;
	public void PushBlocks()
    {
        //Is a block about to hit another block?
        if (numberCastable > 0)
        {
            // Check right
            open = true;
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            hits.AddRange(Physics2D.RaycastAll(gameObject.transform.position, Vector3.right, radius));
            foreach (RaycastHit2D hit in hits)
            {
                if (hit && hit.transform.gameObject != gameObject && hit.transform.gameObject.tag == "Block")
                {
                    List<RaycastHit2D> blocksHit = new List<RaycastHit2D>();
                    Movement blockMove = hit.transform.gameObject.GetComponent<Movement>();
                    for (int i = 1; i <= blockMove.height; i++)
                    {
                        Vector3 upRaycast = hit.transform.position;
                        upRaycast.y += i / 2;
                        Vector3 downRaycast = hit.transform.position;
                        downRaycast.y -= i / 2;
                        blocksHit.AddRange(Physics2D.RaycastAll(upRaycast, Vector3.right, 1f));
                        blocksHit.AddRange(Physics2D.RaycastAll(downRaycast, Vector3.right, 1f));
                    }
                    foreach (RaycastHit2D innerHit in blocksHit)
                    {
                        if (innerHit && innerHit.transform.gameObject != hit.transform.gameObject)
                            open = false;
                    }

                    if (open && hit.transform.gameObject.tag == "Block")
                        hit.transform.position = new Vector3(hit.transform.position.x + distance, hit.transform.position.y, hit.transform.position.z);
                }
            }

            // Check left
            open = true;
            hits.Clear();
            hits.AddRange(Physics2D.RaycastAll(gameObject.transform.position, Vector3.left, radius));
            foreach (RaycastHit2D hit in hits)
            {
                if (hit && hit.transform.gameObject != gameObject && hit.transform.gameObject.tag == "Block")
                {
                    List<RaycastHit2D> blocksHit = new List<RaycastHit2D>();
                    Movement blockMove = hit.transform.gameObject.GetComponent<Movement>();
                    for (int i = 1; i <= blockMove.height; i++)
                    {
                        Vector3 upRaycast = hit.transform.position;
                        upRaycast.y += i / 2;
                        Vector3 downRaycast = hit.transform.position;
                        downRaycast.y -= i / 2;
                        blocksHit.AddRange(Physics2D.RaycastAll(upRaycast, Vector3.left, 1f));
                        blocksHit.AddRange(Physics2D.RaycastAll(downRaycast, Vector3.left, 1f));
                    }
                    foreach (RaycastHit2D innerHit in blocksHit)
                    {
                        if (innerHit && innerHit.transform.gameObject != hit.transform.gameObject)
                            open = false;
                        ;
                    }

                    if (open && hit.transform.gameObject.tag == "Block")
                        hit.transform.position = new Vector3(hit.transform.position.x - distance, hit.transform.position.y, hit.transform.position.z);
                }
            }

            // Check up
            open = true;
            hits.Clear();
            hits.AddRange(Physics2D.RaycastAll(gameObject.transform.position, Vector3.up, radius));
            foreach (RaycastHit2D hit in hits)
            {
                if (hit && hit.transform.gameObject != gameObject && hit.transform.gameObject.tag == "Block")
                {
                    List<RaycastHit2D> blocksHit = new List<RaycastHit2D>();
                    Movement blockMove = hit.transform.gameObject.GetComponent<Movement>();
                    for (int i = 1; i <= blockMove.height; i++)
                    {
                        Vector3 upRaycast = hit.transform.position;
                        upRaycast.y += i / 2;
                        Vector3 downRaycast = hit.transform.position;
                        downRaycast.y -= i / 2;
                        blocksHit.AddRange(Physics2D.RaycastAll(upRaycast, Vector3.up, 1f));
                        blocksHit.AddRange(Physics2D.RaycastAll(downRaycast, Vector3.up, 1f));
                    }
                    foreach (RaycastHit2D innerHit in blocksHit)
                    {
                        if (innerHit && innerHit.transform.gameObject != hit.transform.gameObject)
                            open = false;
                    }

                    if (open && hit.transform.gameObject.tag == "Block")
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + distance, hit.transform.position.z);
                }
            }

            // Check down
            open = true;
            hits.Clear();
            hits.AddRange(Physics2D.RaycastAll(gameObject.transform.position, Vector3.down, radius));
            foreach (RaycastHit2D hit in hits)
            {
                if (hit && hit.transform.gameObject != gameObject && hit.transform.gameObject.tag == "Block")
                {
                    List<RaycastHit2D> blocksHit = new List<RaycastHit2D>();
                    Movement blockMove = hit.transform.gameObject.GetComponent<Movement>();
                    for (int i = 1; i <= blockMove.height; i++)
                    {
                        Vector3 upRaycast = hit.transform.position;
                        upRaycast.y += i / 2;
                        Vector3 downRaycast = hit.transform.position;
                        downRaycast.y -= i / 2;
                        blocksHit.AddRange(Physics2D.RaycastAll(upRaycast, Vector3.down, 1f));
                        blocksHit.AddRange(Physics2D.RaycastAll(downRaycast, Vector3.down, 1f));
                    }
                    foreach (RaycastHit2D innerHit in blocksHit)
                    {
                        if (innerHit && innerHit.transform.gameObject != hit.transform.gameObject)
                            open = false;
                    }

                    if (open && hit.transform.gameObject.tag == "Block")
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y - distance, hit.transform.position.z);
                }
            }

            numberCastable -= 1;
            castableButton.text = numberCastable.ToString();
        }
    }
}
