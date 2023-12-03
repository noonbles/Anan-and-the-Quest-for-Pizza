using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject pizza;
    public Button btn;

    public void OnClick(){
        SceneManager.LoadScene("Game_Level");
    }

    void Start(){
        btn.onClick.AddListener(OnClick);
    }

    void Update()
    {
        pizza.transform.Rotate(Vector3.up * 7f * Time.deltaTime);
    }
}
