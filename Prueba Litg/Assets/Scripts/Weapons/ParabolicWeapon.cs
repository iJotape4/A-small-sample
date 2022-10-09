using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicWeapon : Interactable
{
    public WeaponParabolicScriptableObject parabolicWeapon;
    
    private void Start() {
        name=parabolicWeapon.name;
    }
}
