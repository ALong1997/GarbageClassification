using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public Image star_left;
    public Image star_mid;
    public Image star_right;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void BlingReset()
    {
        star_left.gameObject.SetActive(false);
        star_mid.gameObject.SetActive(false);
        star_right.gameObject.SetActive(false);
    }

    public void Bling(int count)
    {
        if (count >= 1)
            Invoke("Blingbulingleft",1f);
        if (count >= 2)
            Invoke("Blingbulingmid",1.5f);
        if (count >= 3)
            Invoke("Blingbulingright",2f);
    }
    public void Blingbulingleft()
    {
        star_left.gameObject.SetActive(true);
    }
    public void Blingbulingmid()
    {
        star_mid.gameObject.SetActive(true);
    }
    public void Blingbulingright()
    {
        star_right.gameObject.SetActive(true);
    }
}
