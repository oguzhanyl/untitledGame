using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLoop : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public Vector3 offset;

    RaycastHit hit;
    
    private void Update()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,Mathf.Infinity, obstacleLayer))
        {
            transform.LookAt(hit.point);
            transform.rotation *= Quaternion.Euler(offset);
        }
    }
}
