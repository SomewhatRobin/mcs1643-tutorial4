using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("Quitting Game!");
        Application.Quit();
    }
}
