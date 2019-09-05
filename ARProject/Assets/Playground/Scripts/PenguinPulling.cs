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
    public static int PenguinCount;

    [Header("Random Range")]
    [SerializeField]
    int minRange;
    [SerializeField]
    int maxRange;

    #endregion

    #region Accessors
    public int MinRange { get => minRange; set => minRange = value; }
    public int MaxRange { get => maxRange; set => maxRange = value; }
    public ListPenguinManager TilesOccupationManager { get => tilesOccupationManager; set => tilesOccupationManager = value; }

    #endregion
    private void Awake()
    {
        penguinPullList = new List<PenguinBehavior>();
    }
    private void Start()
    {
        TilesOccupationManager = TilesOccupationManager ?? FindObjectOfType<ListPenguinManager>();
    }

   public void RandomActivation(GameObject g)
    {
        g.SetActive(true);
    }
}

