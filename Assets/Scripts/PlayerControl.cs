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
    public PlayerTileMovement tileMovement;
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

    private void LateUpdate()
    {
        if(controllerType == ControllerType.SideScroller)
        {
            SideScrollerMovement();
        }
    }
    public void SideScrollerMovement()
    {
        transform.Translate(Vector3.forward * movVector.x * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }

    }
    public void ChangeToIsometric()
    {
        controllerType = ControllerType.Isometric;
        _anim.SetBool("isometric", true);
        //tileMovement.PrepareBattle();
    }
    public void ChangeToSidescroller()
    {
        Debug.Log("Encounter end");
        _anim.SetBool("isometric", false);
        controllerType = ControllerType.SideScroller;
    }
    public void OnMove(InputValue movementValue)
    {
        movVector = movementValue.Get<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Encounter"))
        {
            Debug.Log("Encounter triggered");
            other.GetComponent<EncounterController>().PrepareBattle();
            // Disable collider to avoid setting up more than once
            other.enabled = false;  
           
            ChangeToIsometric();
        }

        if (other.transform.CompareTag("Finish"))
        {
            Debug.Log("Encounter end");
            _anim.SetBool("isometric", false);
            controllerType = ControllerType.SideScroller;
        }
    }




}
