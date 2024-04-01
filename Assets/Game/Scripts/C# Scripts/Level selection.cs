using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelselection : MonoBehaviour
{
    public void ButtonPressedLevel1()
    {
        SceneManager.LoadScene("level 1");
    }
    public void ButtonPressedLevel2()
    {
        SceneManager.LoadScene("level 2");
    }
    public void ButtonPressedLevel3()
    {
        SceneManager.LoadScene("level 3");
    }
}
