using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu ( fileName = "WeaponMagneticScriptableObject", menuName = "ScriptableObjects/MagneticWeapon")]
public class WeaponForceFieldScriptableObject : ScriptableObject
{
   public new string  name = "MagneticWeapon"; 
    public float magneticForce = 20f;
    public float range = 20f;

    [System.NonSerialized]
    public UnityEvent <float> Magnetizing;

    private void OnEnable(){

        if(Magnetizing ==null){
            Magnetizing = new UnityEvent<float>();
        }
    }

    public void MagnetizeObjects()
    {
        Magnetizing.Invoke(magneticForce);
    }

}
