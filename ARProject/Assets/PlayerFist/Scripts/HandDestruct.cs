using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDestruct : MonoBehaviour
{
    [SerializeField]
    public int coolDownKO;
    [SerializeField]
    bool canHit;

    public bool CanHit { get => canHit; set => canHit = value; }

    private void Start()
    {
        CanHit = true;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //play animation here
            canHit = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Penguin"))
        {
            CanHit = false;
            StartCoroutine(CoolDownKOPenguin());
            CanHit = true;
            Debug.Log("Tu as touché un puinguin GG");
        }
    }

    IEnumerator CoolDownKOPenguin()
    {
        yield return new WaitForSeconds(coolDownKO);

    }
}
