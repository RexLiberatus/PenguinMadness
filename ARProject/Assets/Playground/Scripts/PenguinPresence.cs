using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPresence : MonoBehaviour
{
    [SerializeField]
    bool occupiedByPenguin;
    void Start()
    {
        occupiedByPenguin = false;
    }

   public void PenguinJoinedTile()
    {
        occupiedByPenguin = true;
    }
    public void PenguinLeftTile()
    {
        occupiedByPenguin = false;
    }
}
