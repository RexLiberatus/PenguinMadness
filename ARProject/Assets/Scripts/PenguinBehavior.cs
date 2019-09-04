using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBehavior : MonoBehaviour
{
    [SerializeField]
    int cooldownKO;
    [SerializeField]
    bool hasBeenHit;
    [SerializeField]
    float minCooldown;
    [SerializeField]
    float maxCooldown;

    public bool HasBeenHit { get => hasBeenHit; set => hasBeenHit = value; }

    private void Start()
    {
        if (cooldownKO <= 3)
            cooldownKO = 10;
        HasBeenHit = false;
        
    }
    private void OnEnable()
    {
        float triggerAnimationDelay = Random.Range(minCooldown, maxCooldown);
        //start the main animation sequence 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayGround")//if drops back in the water (or same at the end of the main animation)
        {
            gameObject.SetActive(false);
            other.GetComponent<PenguinPresence>().PenguinLeftTile();
        }
        if(other.tag=="Fist" && !HasBeenHit)//if KO
        {
            HasBeenHit = true;
            //trigger KO animation here

            //add the score value to total
            ScoreManager.score+=1;


            StartCoroutine(CooldownKOPenguin());
            
        }
    }
    IEnumerator CooldownKOPenguin()
    {
        yield return new WaitForSeconds(cooldownKO);
        HasBeenHit = false;
    }

}
