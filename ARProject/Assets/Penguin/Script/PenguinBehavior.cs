using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBehavior : MonoBehaviour
{
    [SerializeField]
    int cooldownKO;
    [SerializeField]
    bool hasBeenHit;
    [Header(" Animation cooldown")]
    [SerializeField]
    float minCooldown;
    [SerializeField]
    float maxCooldown;

    public bool HasBeenHit { get => hasBeenHit; set => hasBeenHit = value; }
    private void Awake()
    {
        PenguinPulling.penguinPullList.Add(this);
    }
    private void Start()
    {
        if (cooldownKO <= 3)
            cooldownKO = 5;
        HasBeenHit = false;
       // gameObject.SetActive(false);

    }
    private void OnEnable()
    {
        float triggerAnimationDelay = Random.Range(minCooldown, maxCooldown);

        //start the main animation sequence 
        transform.Translate(Vector3.up * 5, Space.Self);

    }

    private void OnTriggerEnter(Collider other)
    {
        // USELESS FOR NOW
        //if (other.tag == "PlayGround")//if drops back in the water (or same at the end of the main animation)
        //{
        //    gameObject.SetActive(false);
        //}

        if(other.tag=="Fist" && !HasBeenHit)//Detect of the player hit a penguin.
        {
            if (!HasBeenHit)   //add 1 to score value if penguin has not been hit yet
                ScoreManager.score += 1;

            HasBeenHit = true; // validate that the penguin has been hit

            //trigger KO animation here
            StartCoroutine(CooldownKOPenguin());
            
        }
    }
    IEnumerator CooldownKOPenguin()
    {
        yield return new WaitForSeconds(cooldownKO);
        HasBeenHit = false;
    }

}
