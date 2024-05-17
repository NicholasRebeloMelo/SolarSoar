using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowButton : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
