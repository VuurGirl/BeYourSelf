using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{

    public string levelName;

    void Start()
    {

       
    }

    public void Click()
    {
        Debug.Log("somthing");
           
            SceneManager.LoadScene(levelName);
        
    }
 
}
