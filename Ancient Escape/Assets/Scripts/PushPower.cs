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
                    var blockHits = Physics2D.RaycastAll(hit.transform.position, Vector3.right, hit.transform.GetComponent<Movement>().width/2);
                    foreach (RaycastHit2D innerHit in blockHits)
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
                    var blockHits = Physics2D.RaycastAll(hit.transform.position, Vector3.left, hit.transform.GetComponent<Movement>().width / 2);
                    foreach (RaycastHit2D innerHit in blockHits)
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
                    var blockHits = Physics2D.RaycastAll(hit.transform.position, Vector3.up, hit.transform.GetComponent<Movement>().height / 2);
                    foreach (RaycastHit2D innerHit in blockHits)
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
                    var blockHits = Physics2D.RaycastAll(hit.transform.position, Vector3.down, hit.transform.GetComponent<Movement>().height / 2);
                    foreach (RaycastHit2D innerHit in blockHits)
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
