using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceSystem : MonoBehaviour
{
    [SerializeField] private Button startButton;
    
    private static InterfaceSystem _instance;
    public static InterfaceSystem Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    public void ButtonInteractableControll(string buttonName, bool on)
    {
        if(buttonName == Constance.ButtonsNames.STARTBUTTONNAME)
        {
            startButton.interactable = on;
        }
    }
}
