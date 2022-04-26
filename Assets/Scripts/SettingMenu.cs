using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour

{
    public AudioMixer audioMixer;
    public List<ResItem> resoulutions = new List<ResItem>();

    private int selectedResolution;
    public TMP_Text resolutionLabel;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resoulutions.Count - 1)
        {

            selectedResolution = resoulutions.Count - 1;

        }
        UpdateResLabel();
    }
    public void UpdateResLabel()
    {
        resolutionLabel.text = resoulutions[selectedResolution].horizontal.ToString() + " x " + resoulutions[selectedResolution].vertical.ToString();
    }

}
[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
