using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPulling : MonoBehaviour
{
    #region Datas
    [SerializeField]
    GameObject penguinPrefab;
    [SerializeField]
    float offsetHeight;
    ListTilesManager tilesOccupationManager;
    public static List<GameObject> penguinPullList;
    #endregion

    #region Accessors
    public GameObject PenguinPrefab { get => penguinPrefab; set => penguinPrefab = value; }
    public float OffsetHeight { get => -offsetHeight; set => offsetHeight = value; }
    #endregion
    private void Awake()
    {

    }
    private void Start()
    {
        tilesOccupationManager = tilesOccupationManager ?? FindObjectOfType<ListTilesManager>();

      //get all penguin by foreach

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
        
        bool placed = false;
        foreach (PenguinPresence item in PlaygroundTiles)
        {
            if(!placed)
            {
                if (!item.OccupiedByPenguin)
                {
                    placed = true;
                    item.PenguinJoinedTile();
                    PenguinToPlace.transform.SetParent(item.transform);
                    PenguinToPlace.transform.localScale = penguinPrefab.transform.localScale;
                    PenguinToPlace.transform.localPosition = penguinPrefab.transform.localPosition + new Vector3(0, OffsetHeight, 0);
                    
                }
            }
        }
    }
    int GetRandomValue(int min, int max)
    {
        return Random.Range(min, max);
    }
}

