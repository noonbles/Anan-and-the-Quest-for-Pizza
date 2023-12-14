using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject pizza;

    public void OnClick(){
        SceneManager.LoadScene("GameLevel");
    }

    void Update()
    {
        pizza.transform.Rotate(Vector3.up * 7f * Time.deltaTime);
    }
}
