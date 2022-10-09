using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    Vector2 _horizontalInput;

    [SerializeField] float gravity = -30f;
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    public void ReceiveInput(Vector2 horizontalInput){
        _horizontalInput = horizontalInput;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    isGrounded = Physics.CheckSphere(transform.position , 0.1f, groundMask);
    if(isGrounded){
        verticalVelocity.y =0;
    }

     Vector3 horizontalVelocity = (transform.right * _horizontalInput.x + transform.forward* _horizontalInput.y) *speed;
     controller.Move(horizontalVelocity*Time.deltaTime);

     verticalVelocity.y += gravity* Time.deltaTime;
     controller.Move(verticalVelocity*Time.deltaTime);   
    }
}
