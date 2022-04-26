using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SliderToMixer : MonoBehaviour
    
{
    public Slider slider;
    public AudioMixer audioMixer;
    public string parameterToMatch;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateMixerValue()
    {
        audioMixer.SetFloat(parameterToMatch, slider.value);
        List<string> resolutions = new List<string>();
        int index = 0;
        //both examples are the same
        resolutions.Add(string.Format("{0} x {1}", Screen.resolutions[index].width, Screen.resolutions[index].height));
        //both these resoultions code mean the same thing
        resolutions.Add(""+ Screen.resolutions[index].width + " x " + Screen.resolutions[index].height);

    }
}
