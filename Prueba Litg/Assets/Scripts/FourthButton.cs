using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FourthButton : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimationManager animationManager;

    TextMeshProUGUI text;
    Button button;

    void Start(){
       text= GetComponentInChildren<TextMeshProUGUI>();
       button = GetComponent<Button>();
       button.interactable =false;
       animationManager.animationChangeEvent.AddListener(changeText);
    }

    void changeText ( string newText){
        text.text =  "Select: \n" + newText;
        
        if(!button.interactable)
            button.interactable =true;
    }
}
