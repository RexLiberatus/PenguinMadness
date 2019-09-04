using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTilesManager : MonoBehaviour
{
    [SerializeField]
    List<PenguinPresence> tileList=new List<PenguinPresence>();

    public List<PenguinPresence> TileList { get => tileList; set => tileList = value; }

    private void Start()
    {
        TileList.AddRange(FindObjectsOfType<PenguinPresence>()); 
    }
}
