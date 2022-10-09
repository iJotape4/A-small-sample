using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonsManager : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimationManager animationManager;
    string animHouseDance = "HouseDance";
    string animHipHopDance = "HipHopDance";
    string animMacarenaDance = "MacarenaDance";

    public void onHouseDanceClick(){
        animationManager.ChangePlayerAnimation(animHouseDance);
    }

     public void onHipHopDanceClick(){
        animationManager.ChangePlayerAnimation(animHipHopDance);
    }

     public void onMacarenaDanceClick(){
        animationManager.ChangePlayerAnimation(animMacarenaDance);
    }
}
