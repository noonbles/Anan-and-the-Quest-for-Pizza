using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WinScript : MonoBehaviour
{
    public Text scoreText;
    void Start(){
        scoreText.text = "Score: " + DataWriter.GetScore();
    }
    public void OnClick(){
        SceneManager.LoadScene("Start");
    }
}
