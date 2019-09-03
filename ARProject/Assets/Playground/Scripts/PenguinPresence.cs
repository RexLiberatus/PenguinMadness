using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPresence : MonoBehaviour
{
    [SerializeField]
    bool occupiedByPenguin;
    // Start is called before the first frame update
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
