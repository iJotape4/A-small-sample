using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsManager : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimationManager animationManager;
    string animHouseDance = "HouseDance";
    string animHipHopDance = "HipHopDance";
    string animMacarenaDance = "MacarenaDance";
    string scene2 = "Scene2";

    public void onHouseDanceClick(){
        animationManager.ChangePlayerAnimation(animHouseDance);
    }

    public void onHipHopDanceClick(){
        animationManager.ChangePlayerAnimation(animHipHopDance);
    }

    public void onMacarenaDanceClick(){
        animationManager.ChangePlayerAnimation(animMacarenaDance);
    }

    public void onFourthButtonClick(){
        SceneManager.LoadScene(scene2);
    }
}
