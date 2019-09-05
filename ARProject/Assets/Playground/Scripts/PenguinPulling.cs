using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPulling : MonoBehaviour
{
    #region Datas
    [SerializeField]
    ListPenguinManager tilesOccupationManager;

    public static List<PenguinBehavior> penguinPullList = new List<PenguinBehavior>();
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
        
    }
    private void Start()
    {
        penguinPullList = TilesOccupationManager.GetComponent<ListPenguinManager>().PenguinList;
        minRange = 0;
        maxRange = 15;
        TilesOccupationManager = TilesOccupationManager ?? FindObjectOfType<ListPenguinManager>();
        StartCoroutine(MakePenguinsGreatAgain());
    }

   IEnumerator MakePenguinsGreatAgain()
    {
       
        while(true)
        {
            ActivateRandomPenguinsFromList(TilesOccupationManager.GetComponent<ListPenguinManager>().PenguinList);
            yield return new WaitForSeconds(2f);
        }
    }

    private void Update()
    {

    }
    public void GameobjectActivation(GameObject g)
    {
        g.SetActive(true);
    }
    int GenerateRandomInt(int min, int max)
    {
        return Mathf.RoundToInt(UnityEngine.Random.Range(MinRange,MaxRange));
    }
    public void ActivateRandomPenguinsFromList( List<PenguinBehavior> objectList)
    {
        GameobjectActivation(objectList[GenerateRandomInt(0, objectList.Count-1)].gameObject);
    }
}

