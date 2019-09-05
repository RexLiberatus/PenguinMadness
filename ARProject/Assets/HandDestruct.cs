using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDestruct : MonoBehaviour
{
    [SerializeField]
    public int coolDownKO;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Penguin"))
        {
            StartCoroutine(CoolDownKOPenguin());
            other.GetComponent<PenguinBehavior>().HasBeenHit = true;
            Debug.Log("Tu as touché un puinguin GG");
        }
    }

    IEnumerator CoolDownKOPenguin()
    {
        yield return new WaitForSeconds(coolDownKO);
        GetComponent<PenguinBehavior>().HasBeenHit = false;
    }
}
