using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(MouseLook))]
[RequireComponent(typeof(PickUp))]
[RequireComponent(typeof(Fire))]
public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] PickUp pickUp;
    [SerializeField] Fire fire;
    PlayerControls controls;
    PlayerControls.MovementActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;
    bool interact;
    bool shoot;

    private void Awake()
    {
        movement=GetComponent<Movement>();
        mouseLook=GetComponent<MouseLook>();
        pickUp = GetComponent<PickUp>();
        fire = GetComponent<Fire>();

        controls = new PlayerControls();
        groundMovement = controls.Movement;
 
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDestroy() {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);

        interact = groundMovement.Interact.IsPressed();
        shoot = groundMovement.Fire.WasReleasedThisFrame();

        pickUp.ReceiveInput(interact);
        fire.ReceiveInput(shoot);

    }
}
