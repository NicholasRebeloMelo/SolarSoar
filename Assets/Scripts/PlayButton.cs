using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScreenButton : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
