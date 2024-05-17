using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    private Sprite soundOnImage;
    private bool isMuted = false;
    public Sprite muteImage;
    public Button button;

    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        soundOnImage = button.image.sprite;
        LoadMuteState(); // Load the saved mute state from PlayerPrefs
      
    }

    // Update is called once per frame
    void Update()
    {
        // Update button image based on mute state
        button.image.sprite = isMuted ? muteImage : soundOnImage;
    }

    public void OnMute()
    {
        isMuted = !isMuted; // Toggle mute state on button click

        if (isMuted)
        {
            button.image.sprite = muteImage;
            music.mute = true;
        }
        else
        {
            music.mute = false;
        }
        SaveMuteState(); // Save the updated mute state to PlayerPrefs
    }
    void LoadMuteState()
    {
        isMuted = PlayerPrefs.GetInt("IsMusicMuted", 1) == 1; // Load and handle default value (1 for muted)
        music.mute = isMuted; // Set music mute based on loaded state
    }

    void SaveMuteState()
    {
        PlayerPrefs.SetInt("IsMusicMuted", isMuted ? 1 : 0); // Save mute state to PlayerPrefs (1 for muted)
    }
}
