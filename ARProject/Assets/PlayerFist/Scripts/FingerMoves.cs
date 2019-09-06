using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMoves : MonoBehaviour
{
     Camera _camera;
    [SerializeField]
    public LayerMask layerIndex;
    float YToKeep;
    private void Awake()
    {
        _camera =Camera.main;
        YToKeep = 0.5f;
    }
    private void Start()
    {
        YToKeep = transform.position.y;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Vector3 screenToWorld = _camera.ScreenToWorldPoint(Input.mousePosition);
            //Debug.DrawLine(screenToWorld, _camera.transform.forward * 100 , Color.magenta, 10.0F);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, 1000f, layerIndex))
            {
                Debug.DrawLine(ray.origin,ray.direction * 100, Color.magenta);
                Debug.Log(hitInfo.collider.gameObject.name.ToString());
                Vector3 newPosition = hitInfo.collider.gameObject.transform.position;
                transform.position = new Vector3(newPosition.x, YToKeep, newPosition.z);

            }
        }
    }
}
