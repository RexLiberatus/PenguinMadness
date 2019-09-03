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

   public static List<GameObject> penguinPullList;
    #endregion

    #region Accessors
    public GameObject PenguinPrefab   {get => penguinPrefab; set => penguinPrefab = value;}
    public int NumberOfPenguins { get => numberOfPenguins; set => numberOfPenguins = value; }
    #endregion
    private void Awake()
    {
        if (NumberOfPenguins <6 || NumberOfPenguins >16)
            NumberOfPenguins = 6;

        penguinPullList = new List<GameObject>(NumberOfPenguins);
    }
    private void Start()
    {
        for (int i = 0; i < numberOfPenguins-1; i++)
        {
            penguinPullList.Add(Instantiate(penguinPrefab));
        }
        foreach (GameObject item in penguinPullList)
        {
            item.SetActive(false);
        }
        //call the method that adds penguins foreach of those existing in scene

    }
    //Method that adds a penguin to a free tile
}
