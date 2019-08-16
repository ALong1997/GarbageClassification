using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class RememberScore : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.DeleteAll();
    }

    public void Test()
    {
        //Debug.Log(Application.persistentDataPath);
        string Name = text.text;
        if(File.Exists(Application.persistentDataPath + Name+".txt"))
        {
            string a = File.ReadAllText(Application.persistentDataPath +   Name + ".txt");
            GlobalData.ScorePath = Application.persistentDataPath +  Name + ".txt";
           // Debug.Log(a);
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath +  Name + ".txt", "");
            GlobalData.ScorePath = Application.persistentDataPath +  Name + ".txt";
        }
    }
}
