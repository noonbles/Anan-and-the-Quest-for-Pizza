using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Image blackScreen;
    public GameObject pizza;
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        audioSource.clip = clickSound;
        audioSource.Play();
        Destroy(pizza);
        blackScreen.gameObject.SetActive(true);
        LeanTween.moveY(blackScreen.gameObject, 0, 0.5f).setOnComplete(() =>
        {
            DataWriter.writeData(1, false, 0);
            SceneManager.LoadScene("Level 1");
        });
    }
    void Update()
    {
        if(pizza){
            pizza.transform.Rotate(Vector3.up * 7f * Time.deltaTime);
        }
    }
}
