using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    private PlayerAnimationManager animationManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animationManager.animationChangeEvent.AddListener(ChangeAnimation);
    }

    void ChangeAnimation(string animation){
        anim.SetTrigger(animation);
    }
}
