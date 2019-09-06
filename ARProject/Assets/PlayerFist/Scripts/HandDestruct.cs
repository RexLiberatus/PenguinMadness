using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDestruct : MonoBehaviour
{
    [SerializeField]
    public int coolDownAfterHit;
    [SerializeField]
    bool canHit;
    [SerializeField]
    Animator PawAnimator;

    public bool CanHit { get => canHit; set => canHit = value; }
    public Animator PawAnimator1 { get => PawAnimator; set => PawAnimator = value; }

    private void Start()
    {
        CanHit = true;
    }
    private void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Penguin") && canHit)
        {
            CanHit = false;
            PawAnimator.SetTrigger("PawTrigger");
            StartCoroutine(CoolDownKOPenguin());
            CanHit = true;
            Debug.Log("Tu as touché un puinguin GG");
        }
    }

    IEnumerator CoolDownKOPenguin()
    {
        yield return new WaitForSeconds(coolDownAfterHit);

    }
}
