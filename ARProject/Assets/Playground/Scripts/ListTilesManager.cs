using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTilesManager : MonoBehaviour
{
    [SerializeField]
    List<PenguinPresence> tileList=new List<PenguinPresence>();

    private void Start()
    {
        //PenguinPresence[] TilePointer= FindObjectsOfType<PenguinPresence>();
        tileList.AddRange(FindObjectsOfType<PenguinPresence>());
       //foreach(PenguinPresence element in TilePointer)
       // {
       //     tileList.Add(element.gameObject);
       // }
    }
}
