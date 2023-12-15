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
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        float taxRate = Mathf.Round(Random.Range(0.1f, 0.6f) * 100.0f) / 100.0f;
        float hourlyRate = DataWriter.GetScore() > 20 ? 30f : 15f;
        int hoursWorked = 8;

        infoText.text = string.Format("Tax Rate: {0}% // Hourly Rate: ${1} // Hours Worked: {2}", taxRate, hourlyRate, hoursWorked);

        answerToGrossPay = hourlyRate * hoursWorked;
        answerToNetPay = answerToGrossPay * (1 - taxRate);

        // Debug.Log(answerToGrossPay);
        // Debug.Log(answerToNetPay);

        LeanTween.moveY(infoText.gameObject, 700, 1.0f).setOnComplete(() => {
            Debug.Log("finished moving infotext");
            LeanTween.moveY(grossPay.gameObject, 500, 1.0f);
            LeanTween.moveY(netPay.gameObject, 450, 1.0f);
            LeanTween.moveY(submit.gameObject, 300, 1.0f);
        });
    }

    public void onClick(){
        audioSource.clip = clickSound;
        audioSource.Play();

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
        DataWriter.writeData(nextLevel, IRSSpawn, score);
        LeanTween.moveY(infoText.gameObject, 1000, 1.0f);
        LeanTween.moveY(grossPay.gameObject, -500, 1.0f);
        LeanTween.moveY(netPay.gameObject, -500, 1.0f);
        LeanTween.moveY(submit.gameObject, -500, 1.0f).setOnComplete(()=>{SceneManager.LoadScene("GameLevel");});
        
    }
}
