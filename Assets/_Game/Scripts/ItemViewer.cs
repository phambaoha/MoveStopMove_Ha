using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemViewer : MonoBehaviour, IDragHandler
{
    [SerializeField]
    UIC_ChangeWeapon weapon;
    public float rotationSpeed = 0.5f;

    public void OnDrag(PointerEventData eventData)
    {

        Vector3 rot = new Vector3(-eventData.delta.y, -eventData.delta.x) * rotationSpeed;
        weapon.CurrentWeapon.Rotate(rot, Space.World);
    }


}
