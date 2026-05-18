using UnityEngine;

public class GameInput : MonoBehaviour
{


    private Player_Input_Actions playerInputActions;

    private void Awake()
    {
       playerInputActions = new Player_Input_Actions();
       playerInputActions.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized() 
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

 

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
