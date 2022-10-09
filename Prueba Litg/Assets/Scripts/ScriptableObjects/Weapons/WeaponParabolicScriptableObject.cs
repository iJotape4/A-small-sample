using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( fileName = "WeaponParabolicScriptableObject", menuName = "ScriptableObjects/ParabolicWeapon")]
public class WeaponParabolicScriptableObject : ScriptableObject
{
    public new string  name = "ParabolicWeapon"; 
    public float force = 20f;
    public float angle =45f;
}
