using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPulling : MonoBehaviour
{
    #region Datas
    [SerializeField]
    GameObject penguinPrefab;
    [SerializeField]
    int numberOfPenguins;
    [SerializeField]
    float offsetHeight;
    ListTilesManager tilesOccupationManager;
    public static List<GameObject> penguinPullList;
    #endregion

    #region Accessors
    public GameObject PenguinPrefab { get => penguinPrefab; set => penguinPrefab = value; }
    public int NumberOfPenguins { get => numberOfPenguins; set => numberOfPenguins = value; }
    public float OffsetHeight { get => -offsetHeight; set => offsetHeight = value; }
    #endregion
    private void Awake()
    {
        if (NumberOfPenguins < 6)
            NumberOfPenguins = 6;
        if (NumberOfPenguins > 16)
            NumberOfPenguins = 16;

        penguinPullList = new List<GameObject>(NumberOfPenguins);

    }
    private void Start()
    {
        tilesOccupationManager = tilesOccupationManager ?? FindObjectOfType<ListTilesManager>();
       
        for (int i = 0; i < NumberOfPenguins ; i++)
        {
            penguinPullList.Add(Instantiate(penguinPrefab));
        }
        foreach (GameObject item in penguinPullList)
        {
            item.SetActive(false);
            AddPenguinsOnTile(item, tilesOccupationManager.TileList); //call the method that add a penguin on a free tile
        }

    }
    //Method that adds a penguin to a free tile
    void AddPenguinsOnTile(GameObject PenguinToPlace, List<PenguinPresence> PlaygroundTiles)
    {
        PenguinToPlace.SetActive(true);
        PenguinToPlace.transform.position = new Vector3(0, OffsetHeight, 0);
        bool placed = false;
        foreach (PenguinPresence item in PlaygroundTiles)
        {
            if(!placed)
            {
                if (!item.OccupiedByPenguin)
                {
                    placed = true;
                    item.PenguinJoinedTile();
                    PenguinToPlace.transform.position = new Vector3(0, OffsetHeight, 0)+item.transform.position;
                    PenguinToPlace.transform.SetParent(item.transform);
                    
                }
            }
        }
    }
    int GetRandomValue(int min, int max)
    {
        return Random.Range(min, max);
    }
}

