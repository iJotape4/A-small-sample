using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Fire : MonoBehaviour
{
    bool _fire;
    bool _holdFire;
    public GameObject ballPrefab;
    public GameObject MagneticVFX;
    public Transform gunTransform;
    public PlayerWeaponsManagerScriptableObject weaponsManager;
    
    public WeaponParabolicScriptableObject parabolicScriptableObject;
    public WeaponForceFieldScriptableObject forceFieldScriptableObject;

    public void Start()
    {
        MagneticVFX.SetActive(false);
    }

    public void Update()
    {
        if(!_fire && !_holdFire)
        {
            return;
        }

        if(weaponsManager.currentWeapon == weaponsManager.parabolicWeapon)
        {          
            if(_fire)
            ParabolicShoot();
        }
        else if(weaponsManager.currentWeapon == weaponsManager.magneticWeapon)
        {   
            if(_holdFire)
            {
                MagneticShoot();
            }else
            {
                MagneticVFX.SetActive(false);
            }
            
        }
    }

    public void ParabolicShoot()
    {
        Ball ball = Instantiate(ballPrefab, gunTransform).GetComponent<Ball>();
        ball.ballSpeed = parabolicScriptableObject.force;
        ball.angle = parabolicScriptableObject.angle;
        ball.shotBall();
        ball.transform.parent =null;
    }

    public void MagneticShoot()
    {
        forceFieldScriptableObject.MagnetizeObjects();
        MagneticVFX.SetActive(true);
    }

    public void ReceiveInput(bool fire, bool holdFire)
    {
     _fire = fire;
     _holdFire = holdFire;
    }
}
