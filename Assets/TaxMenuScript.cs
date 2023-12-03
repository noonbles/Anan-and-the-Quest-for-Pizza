using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaxMenuScript : MonoBehaviour
{
    public InputField grossPay;
    public InputField netPay;
    public Text infoText;
    public Button submit;

    private float answerToGrossPay;
    private float answerToNetPay;
    private string nextLevel;

    void Start()
    {
        //TODO: read in a file of some format (prolly json); make sure to clamp to 2 decimal places
        string[] fileData = new String[4];//0: tax rate, 1: hourly rate, 2: hours worked, 3: name of next scene
        float taxRate, hourlyRate;
        int hoursWorked;

        nextLevel = "placeholder lmao ";

        //insert TODO code here

        infoText.text = string.Format("Tax Rate: {0}% // Hourly Rate: ${1} // Hours Worked: {2}", fileData[0], fileData[1], fileData[2]);

        answerToGrossPay = hourlyRate * hoursWorked;
        answerToNetPay = answerToGrossPay * (1 - taxRate);

        submit.gameObject.onClick.AddListener(onClick);
    }

    void onClick(){
        Debug.Log("AAAAAAAAAAAAAAA");
        string grossStr = answerToGrossPay.ToString();
        string netStr = answerToNetPay.ToString();

        string grossSub = grossPay.text;
        string netSub = netPay.text;

        if(string.Equals(grossStr, grossSub) && string.Equals(netStr, netSub)){ //got both correct
            //TODO: write to file got it right, lower chance of IRS spawn by 50%

        }else{
            //TODO: write to file got it wrong, raise chance of IRS spawn by 50%

        }

        SceneManager.LoadScene(nextLevel);
    }
}
