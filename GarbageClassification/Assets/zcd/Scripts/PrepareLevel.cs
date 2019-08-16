using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareLevel : MonoBehaviour
{
    //public GameObject GetReady;
    //public GameObject Go;


    public void Start()
    {
        StartCoroutine(PrepareRoutine());
    }


    IEnumerator PrepareRoutine()
    {
        yield return new WaitForSeconds(0f);


       // GetReady.SetActive(true);


        yield return new WaitForSeconds(2f);


       // GetReady.SetActive(false);
       // Go.SetActive(true);


        yield return new WaitForSeconds(1f);
        //Go.SetActive(false);
    }
}
