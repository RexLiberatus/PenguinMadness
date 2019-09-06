using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDestruct : MonoBehaviour
{
    [SerializeField]
    public int coolDownKO;



    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Penguin"))
        {
            /*
             * pas besoin vu que le pingouin détecte de lui même le hit si l'objet en trigger a un tag "Fist" 
             */
            //other.GetComponent<PenguinBehavior>().HasBeenHit = true;   
            // tu peux par contre déclencher l'animation de la pate d'ours qui smash la cible (a voir avec dylan )
            StartCoroutine(CoolDownKOPenguin());
            Debug.Log("Tu as touché un puinguin GG");
        }
    }

    IEnumerator CoolDownKOPenguin()
    {
        yield return new WaitForSeconds(coolDownKO);
        GetComponent<PenguinBehavior>().HasBeenHit = false;
    }
}
