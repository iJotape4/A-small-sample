using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[CreateAssetMenu(fileName = "PlayerWeaponScriptableObject", menuName ="ScriptableObjects/PlayerWeaponsManager")]
public class PlayerWeaponsManagerScriptableObject : ScriptableObject
{
    public string magneticWeapon = "MagneticWeapon";
    public string parabolicWeapon = "ParabolicWeapon";
    public string currentWeapon;

    public WeaponParabolicScriptableObject parabolicScriptableObject;
    public WeaponForceFieldScriptableObject forceFieldScriptableObject;
    public ScriptableObject currentWeaponScriptableObject;

    [System.NonSerialized]
    public UnityEvent<string> weaponChangeEvent;

    // Start is called before the first frame update
    private void OnEnable(){
        currentWeapon = "";
        if(weaponChangeEvent ==null){
            weaponChangeEvent = new UnityEvent<string>();
        }
    }

    public void ChangePlayerWeapon(string weapon){
        currentWeapon = weapon;
        
        if(weapon == parabolicWeapon)
        {
            currentWeaponScriptableObject = parabolicScriptableObject;
        }
        else if (weapon == magneticWeapon)
        {
            currentWeaponScriptableObject = forceFieldScriptableObject;
        }

        weaponChangeEvent.Invoke(currentWeapon);
    }
}
