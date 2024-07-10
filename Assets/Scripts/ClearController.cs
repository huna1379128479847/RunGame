using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ClearGame);
    }


    void ClearGame()
    {
        SceneManager.LoadScene("Menu");
    }
}