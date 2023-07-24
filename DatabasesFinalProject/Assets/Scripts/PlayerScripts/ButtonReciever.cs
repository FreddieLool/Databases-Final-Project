using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonReciever : MonoBehaviour
{
    public static string ClickedButtonName = "Nun";
    public void ButtonPressed()
    {
        ClickedButtonName = EventSystem.current.currentSelectedGameObject.name;
    }
}
