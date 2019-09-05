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

    [Header("Penguin List")]
    [SerializeField]
    List<PenguinBehavior> PenguinList;
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
        PenguinList = penguinPullList;
        minRange = 0;
        maxRange = 16;
        TilesOccupationManager = TilesOccupationManager ?? FindObjectOfType<ListPenguinManager>();
        StartCoroutine(MakePenguinsGreatAgain());
    }

   IEnumerator MakePenguinsGreatAgain()
    {
        while(true)
        {
            ActivateRandomPenguinsFromList(PenguinList);
            yield return new WaitForSeconds(5.0f);
        }
    }

    private void Update()
    {
 ActivateRandomPenguinsFromList(penguinPullList);
        }
    public void GameobjectActivation(GameObject g)
    {
        g.SetActive(true);
    }
    int GenerateRandomInt(int min, int max)
    {
        return (int)(UnityEngine.Random.Range((float)MinRange, (float)MaxRange));
    }
    public void ActivateRandomPenguinsFromList( List<PenguinBehavior> objectList)
    {
        GameobjectActivation(objectList[GenerateRandomInt(MinRange, maxRange)].gameObject);
    }
}

