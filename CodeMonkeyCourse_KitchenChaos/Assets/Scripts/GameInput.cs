using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{

    public event EventHandler OnInteractAction;

    private PlayerInputActions playerInputActions;
    
    private void Awake()
    { 
        // define the playerinput Action we created and then enable it
        playerInputActions =  new PlayerInputActions();

        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
        // ? checks if left side is null an only runs right side if not null 
        // have to do .Invoke as vant have () after ?
      
    }

    public Vector2 GetMovementVectorNormalised()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
