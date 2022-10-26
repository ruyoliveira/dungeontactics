using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum ControllerType { SideScroller, Isometric};

public class PlayerControl : MonoBehaviour
{
    Vector2 movVector;
    Vector3 jump;
    public float speed;
    public Rigidbody rb;
    public float jumpHeight = 2.0f;
    public bool isGrounded;
    public Animator _anim;
    public ControllerType controllerType = ControllerType.SideScroller;

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
       
    }

    private void LateUpdate()
    {
        if(controllerType == ControllerType.SideScroller)
        {
            transform.Translate(Vector3.forward * movVector.x * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
            }
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
