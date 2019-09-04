using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMoves : MonoBehaviour
{
     Camera _camera;
    [SerializeField]
    private LayerMask layerIndex;
    private void Awake()
    {
        _camera =Camera.main;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Vector3 screenToWorld = _camera.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawLine(screenToWorld, _camera.transform.forward * 100 , Color.magenta, 10.0F);
            RaycastHit hitInfo;
            if(Physics.Raycast(screenToWorld, _camera.transform.forward, out hitInfo, 1000f, layerIndex))
            {
                Debug.DrawLine(screenToWorld, _camera.transform.forward * 100, Color.magenta, 10.0F);
                transform.position = hitInfo.collider.gameObject.transform.position;
            }
        }
    }
}
