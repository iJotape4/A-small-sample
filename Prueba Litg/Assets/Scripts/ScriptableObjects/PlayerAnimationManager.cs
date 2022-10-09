using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerAnimationScriptableObject", menuName ="ScriptableObjects/PlayerAnimationManager")]
public class PlayerAnimationManager : ScriptableObject
{
    public string currentAnimation;

    [System.NonSerialized]
    public UnityEvent<string> animationChangeEvent;
    
    private void OnEnable(){
        currentAnimation = "";
        if(animationChangeEvent ==null){
            animationChangeEvent = new UnityEvent<string>();
        }
    }

    public void ChangePlayerAnimation(string animation){
        currentAnimation = animation;
        animationChangeEvent.Invoke(currentAnimation);
    }
}
