using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Image blackScreen;
    public GameObject pizza;

    public void OnClick(){
        Destroy(pizza);
        blackScreen.gameObject.SetActive(true);
        LeanTween.alpha(blackScreen.gameObject, 1, 3.0f).setOnComplete(()=>{
            DataWriter.writeData(1, false, 0);
            SceneManager.LoadScene("GameLevel");
        });
    }

    void Update()
    {
        if(pizza){
            pizza.transform.Rotate(Vector3.up * 7f * Time.deltaTime);
        }
    }
}
