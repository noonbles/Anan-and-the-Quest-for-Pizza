using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator animationController;
    private Vector3 moveDirection;
    private bool isHoldingPizza;
    private int correctDeliveries;
    private int wrongDeliveries;

    public float speed = 10.0f;
    public float turnSpeed = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent <CharacterController>();
        animationController = GetComponent<Animator>();
        moveDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey ("w"))
        {
            float xdirection = Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
            float zdirection = Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
            moveDirection = new Vector3(xdirection, 0.0f, zdirection);
            animationController.SetBool("isMoving", true);
        }
        else
        {
            moveDirection = Vector3.zero;
            animationController.SetBool("isMoving", false);
        }
        controller.Move(moveDirection * speed * Time.deltaTime);

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
    }
}
