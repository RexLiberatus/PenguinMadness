using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPresence : MonoBehaviour
{
    [SerializeField]
    bool occupiedByPenguin;

    public bool OccupiedByPenguin { get => occupiedByPenguin; set => occupiedByPenguin = value; }

    void Start()
    {
        OccupiedByPenguin = false;
    }

   public void PenguinJoinedTile()
    {
        OccupiedByPenguin = true;
    }
    public void PenguinLeftTile()
    {
        OccupiedByPenguin = false;
    }
}
