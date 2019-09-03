using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTilesManager : MonoBehaviour
{
    [SerializeField]
    List<PenguinPresence> tileList=new List<PenguinPresence>();

    private void Start()
    {
        tileList.AddRange(FindObjectsOfType<PenguinPresence>()); 
    }
}
