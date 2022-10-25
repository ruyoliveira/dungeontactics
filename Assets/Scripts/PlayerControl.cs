using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum ControllerType { SideScroller, Isometric};

public class PlayerControl : MonoBehaviour
{
    Vector2 movVector;
    public float speed;
    public Animator _anim;
    public ControllerType controllerType = ControllerType.SideScroller;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if(controllerType == ControllerType.SideScroller)
        {
            transform.Translate(Vector3.forward * movVector.x * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3( movVector.x- movVector.y, 0, movVector.x + movVector.y) * speed * Time.deltaTime);
        }
    }


    private void OnMove(InputValue movementValue)
    {
        movVector = movementValue.Get<Vector2>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Encounter"))
        {
            Debug.Log("Encounter triggered");
            _anim.SetBool("isometric", true);
            controllerType = ControllerType.Isometric;
        }

        if (other.transform.CompareTag("Finish"))
        {
            Debug.Log("Encounter end");
            _anim.SetBool("isometric", false);
            controllerType = ControllerType.SideScroller;
        }
    }




}
