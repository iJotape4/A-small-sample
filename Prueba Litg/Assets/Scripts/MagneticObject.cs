using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticObject : MonoBehaviour
{
    public GameObject magneticGun;
    public WeaponForceFieldScriptableObject magneticScriptableObject;
    public float _attractionForce= 5f;
    // Start is called before the first frame update
    void Start()
    {       
        magneticScriptableObject.Magnetizing.AddListener(MoveToMagnet);
        if(magneticGun==false)
        {
            magneticGun = GameObject.Find("MagneticWeapon");
        }
    }

    void MoveToMagnet(float attractionForce)
    {
        if(Vector3.Distance(transform.position, magneticGun.transform.position) > magneticScriptableObject.range)
        {
            return;
        }
        _attractionForce =attractionForce;
        transform.position = Vector3.MoveTowards(transform.position, magneticGun.transform.position, Time.deltaTime*attractionForce);
    }
}
