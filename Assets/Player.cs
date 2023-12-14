using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator animationController;
    public Vector3 moveDirection;
    public bool isHoldingPizza = false;
    public string heldPizzaName = "";
    public int correctDeliveries;
    public int wrongDeliveries;
    private float gravity;

    public float speed = 10.0f;
    public float turnSpeed = 150.0f;
    public float totalTime = 120f;
    public float currentTime;
    public float totalStamina = 13f;
    public float stamina;
    public bool isAlive;
    public Image staminaBar;
    public Text timer;
    public Image blackScreen;
    public Text delivery;
    private bool animationDone;

    void Start()
    {
        controller = GetComponent <CharacterController>();
        animationController = GetComponent<Animator>();
        moveDirection = Vector3.zero;
        currentTime = totalTime;
        stamina = totalStamina;
        isAlive = true;
        gravity = 20f;
        LeanTween.moveX(blackScreen.gameObject, 2900, 1.0f).setOnComplete(()=>{animationDone = true;});
    }

    void Update()
    {
        if(animationDone){
            handleRoundTimer();
            handleGameState();
            handlePizza();
            staminaBar.rectTransform.sizeDelta = new Vector2((stamina/totalStamina) * 1200, 30);

            if (Input.GetKey ("w"))
            {
                //STAMINA BAR; LASTS 13 SECONNDS AND DOES NOT REPLENISH UNLESS GRANTED BY SOMETHING ELSE
                if(Input.GetKey ("left shift") && stamina > 0){
                    speed = 15.0f;
                    stamina -= Time.deltaTime;
                }else{
                    speed = 10.0f;
                }


                float xdirection = Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
                float zdirection = Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
                moveDirection = new Vector3(xdirection, 0.0f, zdirection);
                animationController.SetBool("isMoving", true);
            }
            // else if (Input.GetKey("s"))
            // {
            //     float xdirection = Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
            //     float zdirection = Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
            //     moveDirection = new Vector3(-xdirection, 0.0f, -zdirection);
            //     animationController.SetBool("isMoving", true);
            // }
            else
            {
                moveDirection = Vector3.zero;
                animationController.SetBool("isMoving", false);
            }
            if (!controller.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            controller.Move(moveDirection * speed * Time.deltaTime);

            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        }
    }

    void handleGameState(){
        if(!isAlive){
            LeanTween.moveX(blackScreen.gameObject, 300, 1.0f).setOnComplete(()=>{
                SceneManager.LoadScene("Game_Over");
            });
        }
    }

    void handleRoundTimer(){
        if(currentTime > 0){
            currentTime -= Time.deltaTime;
            timer.text = "TIME LEFT: " + (int)currentTime + " SECONDS";
            if(currentTime < 20)
                timer.color = Color.red;
        }else{
            DataWriter.writeData(0, false, correctDeliveries * 15 - wrongDeliveries * 5);
            LeanTween.moveX(blackScreen.gameObject, 300, 1.0f).setOnComplete(()=>{SceneManager.LoadScene("Taxes_Menu");});
        }
    }

    void handlePizza(){
        Transform pizza = transform.Find("Pizza");
        bool active = isHoldingPizza && !heldPizzaName.Equals("");
        delivery.text = "Deliver this pizza to: " + heldPizzaName;
        delivery.gameObject.SetActive(active);
        pizza.gameObject.SetActive(active);
        pizza.Rotate(Vector3.up * 7f * Time.deltaTime);
    }
}
