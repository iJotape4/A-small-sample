using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerWeaponScriptableObject", menuName ="ScriptableObjects/PlayerWeaponsManager")]
public class PlayerWeaponsManagerScriptableObject : ScriptableObject
{
    public string currentWeapon;

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
        weaponChangeEvent.Invoke(currentWeapon);
    }
}
