using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{

    public Button cont;
    public Text gameOver;
    public Text score;
    public AudioClip clickSound;
    private AudioSource audioSource;
    void Start(){
        audioSource = GetComponent<AudioSource>();
        LeanTween.scale(gameOver.gameObject, new Vector2(1, 1), 1.0f).setOnComplete(()=>{
            Debug.Log("game over scaling done");
            LeanTween.moveY(cont.gameObject, 400, 1.0f);
            score.text = "Score: " + DataWriter.GetScore();
            LeanTween.moveY(score.gameObject, 500, 1.0f);
        });
    }
    public void OnClick(){
        audioSource.clip = clickSound;
        audioSource.Play();
        DataWriter.writeData(1, false, 0);
        SceneManager.LoadScene("Level 1");
    }
}
