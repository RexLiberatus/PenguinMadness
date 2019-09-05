using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPenguinManager : MonoBehaviour
{
    [SerializeField]
    List<PenguinBehavior> penguinList=new List<PenguinBehavior>();

    public List<PenguinBehavior> Penguin { get => penguinList; set => penguinList = value; }

    private void Start()
    {
        Penguin.AddRange(FindObjectsOfType<PenguinBehavior>()); 
    }
}
