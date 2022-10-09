using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    bool _interact;
    [SerializeField] private Interactable pickedItem;

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material higLightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;
    [SerializeField] private Camera _cam;

    private void Update()
    {
        PickItem();
    }

    public void PickItem()
    {
        if(_selection!=null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;           
        }
        var ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            var selection = hit.transform;
            if(selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null)
                {
                    selectionRenderer.material = higLightMaterial;
                }
                _selection = selection;
                if(_interact)
                {
                    if(pickedItem!=null)
                    {
                        pickedItem.Interact(false);
                    }

                   pickedItem = _selection.GetComponent<Interactable>();
                   pickedItem.Interact(true);
                }
            }
        }
    }

    public void ReceiveInput(bool interact){
        _interact = interact;
    }
}
