using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPulling : MonoBehaviour
{
    #region Datas
    [SerializeField]
    ListPenguinManager tilesOccupationManager;

    public static List<PenguinBehavior> penguinPullList;
    #endregion

    #region Accessors

    #endregion
    private void Awake()
    {

    }
    private void Start()
    {
        tilesOccupationManager = tilesOccupationManager ?? FindObjectOfType<ListPenguinManager>();

      



    }


}

