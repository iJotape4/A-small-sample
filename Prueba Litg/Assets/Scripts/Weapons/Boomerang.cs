using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Interactable
{
    public WeaponBoomerangScriptableObject boomerang;
    private void Start() {
        name=boomerang.name;
    }
}
