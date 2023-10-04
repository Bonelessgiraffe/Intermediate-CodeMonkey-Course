using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [SerializeField] private float speed = 5f;
    [SerializeField] private float rotSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        Vector2 inputVector = new Vector2(0, 0);
       if ( Input.GetKey(KeyCode.W))
       {
            inputVector.y = +1;
       }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        //Having input vector separate from the actual movement makes it a lot easier to vhange control to gamepad
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y) * Time.deltaTime * speed;

        //rotate to where to player is facing
        //needs to be a smooth transition so we use slerp
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotSpeed);
        transform.position += moveDir;

    }
}
