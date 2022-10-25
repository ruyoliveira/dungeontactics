using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Add tiles to an array, raycast the tile user is on and use the array to color the target field

public class PlayerTiles : MonoBehaviour
{
    public Vector3 rayCollisionUp = Vector3.zero;
    public Vector3 rayCollisionDown = Vector3.zero;
    public Vector3 rayCollisionLeft = Vector3.zero;
    public Vector3 rayCollisionRight = Vector3.zero;

    public GameObject tileUp;
    public GameObject tileDown;
    public GameObject tileLeft;
    public GameObject tileRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast tile front
        Ray ray = new Ray(this.transform.position, Quaternion.Euler(40, 0, 0) * this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 40))
        {
            Debug.Log("Hit: " + hit.transform.gameObject.name);
            rayCollisionUp = hit.point;
            tileUp = hit.transform.gameObject;
            tileUp.GetComponent<Tile>().SetColor(1);

        }
        else
        {
            // Reset tile color
            if (tileUp != null)
            {
                tileUp.GetComponent<Tile>().SetColor(0);
            }
            tileUp = null;
        }
        // Raycast tile back
        ray = new Ray(this.transform.position, Quaternion.Euler(140, 0, 0) * this.transform.forward);
        if (Physics.Raycast(ray, out hit, 40))
        {
            Debug.Log("Hit: " + hit.transform.gameObject.name);
            rayCollisionDown = hit.point;
            tileDown = hit.transform.gameObject;
            tileDown.GetComponent<Tile>().SetColor(1);


        }
        else
        {
            tileDown = null;
        }
        // Raycast tile left
        ray = new Ray(this.transform.position, Quaternion.Euler(40, -90, 0) * this.transform.forward);
        if (Physics.Raycast(ray, out hit, 40))
        {
            Debug.Log("Hit: " + hit.transform.gameObject.name);
            rayCollisionLeft = hit.point;
            tileLeft = hit.transform.gameObject;
            tileLeft.GetComponent<Tile>().SetColor(1);


        }
        else
        {

            tileLeft = null;
        }
        // Raycast tile right
        ray = new Ray(this.transform.position, Quaternion.Euler(40, 90, 0) * this.transform.forward);
        if (Physics.Raycast(ray, out hit, 40))
        {
            Debug.Log("Hit: " + hit.transform.gameObject.name);
            rayCollisionRight = hit.point;
            tileRight = hit.transform.gameObject;
            tileRight.GetComponent<Tile>().SetColor(1);


        }
        else
        {

            tileRight = null;
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rayCollisionUp, 0.2f);
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(rayCollisionDown, 0.2f);
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(rayCollisionLeft, 0.2f);
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(rayCollisionRight, 0.2f);


    }
}
