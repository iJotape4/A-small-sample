using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu ( fileName = "WeaponParabolicScriptableObject", menuName = "ScriptableObjects/MagneticWeapon")]
public class WeaponForceFieldScriptableObject : ScriptableObject
{
   public new string  name = "MagneticWeapon"; 
    public float magneticForce = 20f;
    public float range = 20f;

}
