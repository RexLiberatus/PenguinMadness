using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBehavior : MonoBehaviour
{
    [SerializeField]
    int cooldownKO;
    bool hasBeenHit;
    private void Start()
    {
        if (cooldownKO <= 0)
            cooldownKO = 1;
        hasBeenHit = false;
        
    }
    private void OnEnable()
    {

        //start the main animation
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayGround")//if drops back in the water (or same at the end of the main animation)
        {
            gameObject.SetActive(false);
            other.GetComponent<PenguinPresence>().PenguinLeftTile();

        }
        if(other.tag=="Fist" && !hasBeenHit)//if KO
        {
            hasBeenHit = true;
            //trigger KO animation here
            //add the score value to total
            //play the corroutine that delay the desactivation of the penguin
            StartCoroutine(CooldownKOPenguin());
        }
    }
    IEnumerator CooldownKOPenguin()
    {
        yield return new WaitForSeconds(cooldownKO);
        gameObject.SetActive(false);
    }

}
