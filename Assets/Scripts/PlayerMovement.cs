using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 1f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 moveInputs = Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);
    }
}
