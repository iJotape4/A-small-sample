using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeaponsManager : MonoBehaviour
{
    public PlayerWeaponsManagerScriptableObject weaponsManager;

    GameObject[] children ;

    public void Start()
    {
        weaponsManager.weaponChangeEvent.AddListener(EnableWeapon);       
        hideAll();
    }

    public void EnableWeapon(string weapon)
    {
        foreach ( GameObject go in children)
        {
            if(go.name == weapon)
            {
                go.SetActive(true);
            }else
            {
                go.SetActive(false);
            }
        }
    }

    public void hideAll()
    {
    children =  new GameObject[transform.childCount];
    for (int i = 0; i < children.Length; ++i)
    {
    children[i] = transform.GetChild(i).gameObject;
    children[i].SetActive(false);
    }
    }
}
