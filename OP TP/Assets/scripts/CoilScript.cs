using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoilScript : MonoBehaviour
{
    public GameObject Hero;
    
    void Start()
    {
        StartCoroutine(die(0.5f));
    }   

    IEnumerator die(float timeLife)
    {
        yield return new WaitForSeconds(timeLife);
        
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && other.gameObject != Hero)
        {
            other.GetComponent<ShadowFiendMove>().ChangeHealth(-20);
        }
    }
}
