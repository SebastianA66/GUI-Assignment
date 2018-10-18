using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Interacting with scene changes
using UnityEngine.UI; // Interacting with GUI elements
using UnityEngine.EventSystems; //event controlling

public class MainMenu : MonoBehaviour
{
    //Save data options menu HW 
    #region Variables
    [Header("Options")]
    public bool showOptions;
    public Vector2[] res = new Vector2[8];
    public int resIndex;
    public bool isFullscreen;
    [Header("References")]
    public AudioSource mainAudio;
    public Light dirLight;
    public Dropdown resDropDown;
    public GameObject mainMenu, optionsMenu;
    public Slider volSlider, brightSlider;

    
    #endregion

    void Start()
    {

        mainAudio = GameObject.Find("MainMusic").GetComponent<AudioSource>();
        
        
    }

    

    public void LoadGame() // The ability to load into a different scene
    {
        SceneManager.LoadScene(1);
    }


    public void ExitGame()
    {
#if UNITY_EDITOR // exit button can be presed in testing mode
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ToggleOptions()
    {
        OptionToggle();
    }

    bool OptionToggle()
    {
        if (showOptions)//showOptions == true or showOptions is true
        {
            showOptions = false;
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            return true;
        }
        else
        {
            showOptions = true;
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            volSlider = GameObject.Find("AudioSlider").GetComponent<Slider>();
            volSlider.value = mainAudio.volume;
            brightSlider = GameObject.Find("BrightnessSlider").GetComponent<Slider>();
            brightSlider.value = dirLight.intensity;
            resDropDown = GameObject.Find("Resolution").GetComponent<Dropdown>();
            return false;
        }
    }

    public void Volume()
    {
        mainAudio.volume = volSlider.value;
    }

    public void Brightness()
    {
        dirLight.intensity = brightSlider.value;
    }
}

    //public void Resolution()
    //{
    //    Resolution[] resolution = Screen.resolutions;
    //    foreach (Resolution res in resolution)
    //    {
    //        print(message: res.width = "x" + res.height);
    //    }
    //
    //    Screen.SetResolution(resolution[0].width, resolution[0].height, true);
    //    //resIndex = resDropDown.value;
    //    //Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullscreen);
    //}

  

  