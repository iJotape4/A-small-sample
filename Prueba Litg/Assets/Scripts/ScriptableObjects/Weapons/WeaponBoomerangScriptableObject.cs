using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu ( fileName = "WeaponBoomerangScriptableObject", menuName = "ScriptableObjects/BoomerangWeapon")]
public class WeaponBoomerangScriptableObject : ScriptableObject
{
    public new string  name = "BoomerangWeapon"; 
    public float ShotForce = 20f;
    public float range = 10f;

     [System.NonSerialized]
    public UnityEvent <float> LaunchBoomerangEvent;

     private void OnEnable(){

        if(LaunchBoomerangEvent ==null){
            LaunchBoomerangEvent = new UnityEvent<float>();
        }
    }

    public void LaunchBoomerang()
    {
        LaunchBoomerangEvent.Invoke(ShotForce);
    }


}
