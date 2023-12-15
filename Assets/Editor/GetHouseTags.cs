using UnityEditor;
using UnityEngine;

public class GetHouseTags : MonoBehaviour
{
    [MenuItem("Debug/Get House Tags")]
    public static void getHouseTags()
    {
        GameObject[] GOList = GameObject.FindGameObjectsWithTag("House");
        foreach(GameObject g in GOList)
        {
            Debug.Log(g.name);
        }
    }
}