using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [SerializeField] private float speed = 5f;
    [SerializeField] private float rotSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalised();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y) ;

        float playerRadius = 0.7f;
        float playerHeight = 2f;
        float moveDistance = speed * Time.deltaTime;
        //canMove is true if the raycast of player radius does not hit anything

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position +
            Vector3.up * playerHeight,  playerRadius, moveDir, moveDistance);

        //to make diagonal movement work if one axis is blocked 
        if (!canMove)
        {
            //cannot move towards moveDir
            //Attempt only X move
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position +
            Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                //Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                //Cannot move only on the X

                //Attempt only z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position +
                Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {//can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }

        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance; 
        }
        isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
