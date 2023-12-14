using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void OnClick(){
        SceneManager.LoadScene("GameLevel");
        //TODO: WRITE FILE SET GAME LEVEL TO 1;
    }
}
