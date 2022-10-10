using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Fire : MonoBehaviour
{
    bool _fire;
    public GameObject ballPrefab;
    public Transform gunTransform;
    public PlayerWeaponsManagerScriptableObject weaponsManager;
    
    public WeaponParabolicScriptableObject parabolicScriptableObject;
    public WeaponForceFieldScriptableObject forceFieldScriptableObject;

    public void Update()
    {
        if(!_fire)
        {
            return;
        }

        if(weaponsManager.currentWeapon == weaponsManager.parabolicWeapon)
        {          
            ParabolicShoot();
        }
        else if(weaponsManager.currentWeapon == weaponsManager.magneticWeapon)
        {
            MagneticShoot();
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

    }

    public void ReceiveInput(bool fire)
    {
     _fire = fire;
    }
}
