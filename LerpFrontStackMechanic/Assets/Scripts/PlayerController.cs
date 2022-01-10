using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float swerveSpeed;

    private float touchPosX;
    private void FixedUpdate()
    {
    
        PlayerMovementControl();

    }

    private void PlayerMovementControl()
    {
        // Player Forward Movement
        transform.position += Vector3.forward * Time.fixedDeltaTime * movementSpeed;

        if (Input.GetMouseButton(0))
        {
            touchPosX += Input.GetAxis("Mouse X") * swerveSpeed * Time.fixedDeltaTime;

            transform.position = new Vector3(touchPosX,transform.position.y,transform.position.z);
        }
    }
}
