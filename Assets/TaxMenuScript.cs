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
    private float answerToGrossPay;
    private float answerToNetPay;

    void Start()
    {
        float taxRate = Mathf.Round(Random.Range(0.1f, 0.6f) * 100.0f) / 100.0f;
        float hourlyRate = DataWriter.GetScore() > 20 ? 30f : 15f;
        int hoursWorked = 8;

        infoText.text = string.Format("Tax Rate: {0}% // Hourly Rate: ${1} // Hours Worked: {2}", taxRate, hourlyRate, hoursWorked);

        answerToGrossPay = hourlyRate * hoursWorked;
        answerToNetPay = answerToGrossPay * (1 - taxRate);

        // Debug.Log(answerToGrossPay);
        // Debug.Log(answerToNetPay);

        
    }

    public void onClick(){
        string grossStr = answerToGrossPay.ToString();
        string netStr = answerToNetPay.ToString();

        string grossSub = grossPay.text;
        string netSub = netPay.text;

        int nextLevel = DataWriter.GetLevel() + 1;
        int score = DataWriter.GetScore();
        bool IRSSpawn = true;
        if(string.Equals(grossStr, grossSub) && string.Equals(netStr, netSub)){ //got both correct
            IRSSpawn = false;
            score += 50;
        }
        DataWriter.writeData(nextLevel, true, score);
        SceneManager.LoadScene("GameLevel");
    }
}
