using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator animationController;
    private Vector3 moveDirection;
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

    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent <CharacterController>();
        animationController = GetComponent<Animator>();
        moveDirection = Vector3.zero;
        currentTime = totalTime;
        stamina = totalStamina;
        gravity = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        handleRoundTimer();

        //STAMINA BAR; LASTS 13 SECONNDS AND DOES NOT REPLENISH UNLESS GRANTED BY SOMETHING ELSE
        if(Input.GetKey ("left shift") && stamina > 0){
            //TODO: CREATE A BAR THAT RESIZES BASED ON STAMINA PROPORTION STAMINA/TOTALSTAMINAz
            speed = 15.0f;
            stamina -= Time.deltaTime;
        }else{
            speed = 10.0f;
        }

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
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        controller.Move(moveDirection * speed * Time.deltaTime);

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
    }

    void writeDataToFile(int gameLevel, bool irsSpawn){
        //TODO: CREATE A FILE FOR THE TAX MENU SCRIPT TO READ
        //WE NEED TO STORE THE CURRENT LEVEL AND IS IRS SPAWNING
        //IF FIRST LEVEL, IRS SPAWNING IS FALSE; ONLY CHANGE TO TRUE IN THE TAX MENU SCRIPT IF PLAYER GETS ANSWER(S) WRONG
        //MAY NEED MORE FIELDS TO SAVE BUT CANT THINK OF ANY AT THE MOMENT
        
    }

    void handleRoundTimer(){
        //ROUND TIMER
        if(currentTime > 0){
            //TODO: CREATE A VARIABLE FOR TIMER GAME OBJECT AND MODIFY IT HERE
            currentTime -= Time.deltaTime;
            timer.text = "TIME LEFT: " + (int)currentTime + " SECONDS";
            if(currentTime < 20){
                timer.color = Color.red;
            }
        }else{
            //TIMES UP BITCH
            writeDataToFile(0, false);
            SceneManager.LoadScene("Taxes_Menu"); //THIS MIGHT NOT BE THE RIGHT NAME RN
        }
    }
}
