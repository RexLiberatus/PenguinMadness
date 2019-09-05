using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPenguinManager : MonoBehaviour
{
    [SerializeField]
    List<PenguinBehavior> penguinList=new List<PenguinBehavior>();

    public List<PenguinBehavior> PenguinList { get => penguinList; set => penguinList = value; }

    private void Awake()
    {
        PenguinList.AddRange(FindObjectsOfType<PenguinBehavior>());
       
    }
}
