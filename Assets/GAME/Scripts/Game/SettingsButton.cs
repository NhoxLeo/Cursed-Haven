using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{

    public Button buttonOn;
    public Button buttonOff;
    private bool isEnable = true;
    public TextMeshProUGUI textOn;
    public TextMeshProUGUI textOff;




    public void SetFullScreen()
    {

        switch (isEnable)
        {

            case true:
                Screen.fullScreen = true;
                break;


            case false:
                Screen.fullScreen = false;
                break;

        }
    }






    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }







    public void TriggerButton() {


        switch (isEnable) {

            case true:

                ColorBlock colorsOn1 = buttonOn.colors;
                colorsOn1.normalColor = Color.black;
                colorsOn1.selectedColor = Color.black;
                buttonOn.colors = colorsOn1;
                textOn.color = new Color32(255,255,255,50);



                ColorBlock colorOff1 = buttonOff.colors;
                colorOff1.normalColor = Color.white;
                colorOff1.selectedColor = Color.white;
                buttonOff.colors = colorOff1;
                textOff.color = new Color(0, 0, 0, 255);

                isEnable = false;
                break;


            case false:

                ColorBlock colorsOn2 = buttonOn.colors;
                colorsOn2.normalColor = Color.white;
                colorsOn2.selectedColor = Color.white;
                buttonOn.colors = colorsOn2;
                textOn.color = new Color(0, 0, 0, 255);


                ColorBlock colorOff2 = buttonOff.colors;
                colorOff2.normalColor = Color.black;
                colorOff2.selectedColor = Color.black;
                buttonOff.colors = colorOff2;
                textOff.color = new Color32(255, 255, 255, 50);

                isEnable = true;
                break;


        }
    }






    public void ReturnMainMenu()
    {

        SceneManager.LoadScene(0);
    }

    public void RestartGame() {

        SceneManager.LoadScene(1);
    }


}
