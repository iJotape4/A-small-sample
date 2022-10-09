using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool pickedItem;
    public new string name;
    public void Interact(bool picked){
        
        foreach(MeshRenderer mr in  gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            mr.enabled = !picked;    
        }
        gameObject.GetComponent<BoxCollider>().enabled = !picked;
        gameObject.GetComponent<Rigidbody>().isKinematic = picked;
        pickedItem = picked;
    }
}
