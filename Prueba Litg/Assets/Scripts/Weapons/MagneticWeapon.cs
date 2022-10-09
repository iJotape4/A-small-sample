using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticWeapon : Interactable
{
    public WeaponForceFieldScriptableObject magneticWeapon;

    private void Start() {
        name=magneticWeapon.name;
    }
}
