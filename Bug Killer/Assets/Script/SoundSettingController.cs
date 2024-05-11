using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingController : MonoBehaviour
{
    public Slider BGMSlider, FXSlider;
    public AudioSource[] BGMSound;
    public AudioSource[] FXSound;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("SBGM"))
        {
            BGMSlider.value = 0.5f;
            PlayerPrefs.SetFloat("SBGM", BGMSlider.value);
        }
        else
        {
            BGMSlider.value = PlayerPrefs.GetFloat("SBGM");
        }

        if (!PlayerPrefs.HasKey("SFX"))
        {
            FXSlider.value = 0.5f;
            PlayerPrefs.SetFloat("SFX", FXSlider.value);
        }
        else
        {
            FXSlider.value = PlayerPrefs.GetFloat("SFX");
        }

        for (int i = 0; i < BGMSound.Length; i++)
        {
            BGMSound[i].volume = PlayerPrefs.GetFloat("SBGM");
        }

        for (int i = 0; i < FXSound.Length; i++)
        {
            FXSound[i].volume = PlayerPrefs.GetFloat("SFX");
        }

        for (int i = 0; i < BGMSound.Length; i++)
        {
            BGMSound[i].Play();
        }
    }

    public void ChangeValueBGM()
    {
        for (int i = 0; i < BGMSound.Length; i++)
        {
            BGMSound[i].volume = BGMSlider.value;
        }

        PlayerPrefs.SetFloat("SBGM", BGMSlider.value);
    }

    public void ChangeValueFX()
    {
        for (int i = 0; i < BGMSound.Length; i++)
        {
            FXSound[i].volume = FXSlider.value;
        }

        PlayerPrefs.SetFloat("SFX", FXSlider.value);
    }
}