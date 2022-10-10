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
    public GameObject boomerang;
    bool _inBoomerang ;
    public Transform gunTransform;
    public PlayerWeaponsManagerScriptableObject weaponsManager;
    
    public WeaponParabolicScriptableObject parabolicScriptableObject;
    public WeaponForceFieldScriptableObject forceFieldScriptableObject;
    public WeaponBoomerangScriptableObject boomerangScriptableObject;

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
            
        }else if(weaponsManager.currentWeapon == weaponsManager.boomerangWeapon)
        {
            if(_fire && !_inBoomerang)
                StartCoroutine(BoomerangShoot());
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

    public IEnumerator BoomerangShoot()
    {
        boomerangScriptableObject.LaunchBoomerang();

        boomerang.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
			
			Vector3 OriginalScale = boomerang.transform.localScale;
			GameObject OriginalPosition = Instantiate(new GameObject("OriginalBoomerangPosition"), boomerang.transform.parent);
			OriginalPosition.transform.localPosition = boomerang.transform.localPosition ;
			OriginalPosition.transform.localRotation = boomerang.transform.localRotation ;

			boomerang.transform.SetParent(null);
			

			float shotForce = boomerangScriptableObject.ShotForce;
			Rigidbody boomerangRigidbody = boomerang.GetComponent<Rigidbody>();
			boomerangRigidbody.AddForce(-OriginalPosition.transform.up * Mathf.Clamp(shotForce, 800f, 30000f));
			boomerangRigidbody.AddTorque(OriginalPosition.transform.right * (Mathf.Clamp(shotForce, 800f, 30000f)/4), ForceMode.Force);
			
			_inBoomerang = true;

			yield return new WaitForSeconds(1f);

			boomerangRigidbody.velocity = new Vector3(0f, 0f, 0f);		
			
			boomerangRigidbody.transform.SetParent(OriginalPosition.transform.parent);
			while (boomerangRigidbody.transform.position != OriginalPosition.transform.position)
            {
				boomerangRigidbody.transform.position = Vector3.MoveTowards(boomerangRigidbody.transform.position, OriginalPosition.transform.position, (shotForce*4)*Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}

			boomerang.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			boomerangRigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
			boomerang.transform.rotation = OriginalPosition.transform.rotation;
			boomerang.transform.localScale = OriginalScale;
			
			Destroy(OriginalPosition);
			Destroy(GameObject.Find("OriginalBoomerangPosition"));

			while(boomerang.GetComponent<Rigidbody>().constraints != RigidbodyConstraints.FreezeAll)
            {
				yield return new WaitForEndOfFrame();				
			}
			_inBoomerang = false;
    }

    public void ReceiveInput(bool fire, bool holdFire)
    {
     _fire = fire;
     _holdFire = holdFire;
    }
}
