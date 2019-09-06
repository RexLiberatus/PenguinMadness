using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBehavior : MonoBehaviour
{
    #region Data
    [Header("Control Data")]
    [SerializeField]
    int cooldownKO;
    [SerializeField]
    bool hasBeenHit;
    [SerializeField]
    float speed = 1;
    AudioSource audioData;
    [SerializeField]
    bool isGoingUp;
    [SerializeField]
    bool isGoingDown;
    #endregion
    #region Accessors

    public bool HasBeenHit { get => hasBeenHit; set => hasBeenHit = value; }
    public float Speed { get => speed; set => speed = value; }
    #endregion
    #region Start

    private void Start()
    {
        audioData = new AudioSource();
        audioData.clip = FindObjectOfType<AudioManager>().PenguinShout;
        isGoingDown = isGoingUp = false;
        if (cooldownKO <= 3)
            cooldownKO = 5;
        HasBeenHit = false;
        gameObject.SetActive(false);

    }    
    #endregion
    private void OnEnable()
    {
        isGoingDown = false;
        Speed = 1;
        isGoingUp = true;
        audioData.PlayOneShot(audioData.clip);
        //start the main animation sequence 
        

    }
    private void Update()
    {
        if(isGoingUp)
        {
            if (transform.localPosition.y < 0.9f)
            {
                transform.localPosition += Vector3.up * Time.deltaTime * Speed;
            }
        }
        if (transform.localPosition.y >= 0.9f)
        {
            isGoingUp = false;
            StartCoroutine(DelayFall());
            isGoingDown = true;
        }
            if (isGoingDown)
        {
            if (transform.localPosition.y > -0.7f)
            {
                transform.localPosition -= Vector3.up * Time.deltaTime * Speed;
            }
            if(transform.localPosition.y<=-0.7f && !isGoingUp)
            {
                gameObject.SetActive(false);
            }
        }
           


    }

    IEnumerator DelayFall()
    {
        yield return new WaitForSeconds(2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Fist" && !HasBeenHit)//Detect of the player hit a penguin.
        {
        HandDestruct controlerHand = other.GetComponent<HandDestruct>();
            if (!HasBeenHit)   //add 1 to score value if penguin has not been hit yet
                ScoreManager.score += 1;

            HasBeenHit = true; // validate that the penguin has been hit

            isGoingDown = true;
            //trigger KO animation here
            GetComponent<Animator>().SetBool("isStunt", true);
            StartCoroutine(CooldownKOPenguin());
            HasBeenHit = false;
            isGoingUp = false;
            //trigger back to idle here
            GetComponent<Animator>().SetBool("isStunt", false);
        }
    }
    IEnumerator CooldownKOPenguin()
    {
        yield return new WaitForSeconds(cooldownKO);
       
    }

}
