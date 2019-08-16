using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEdit : MonoBehaviour {
    public GameObject main;
    public GameObject gameStart;
    public InputField textLevel;
    public InputField textId;
    public InputField textStartPositon;
    public InputField textRunTime;
    public InputField textHeight;
    public InputField textStartTime;
    public InputField textRunId;
    public InputField textEffect;


    private List<LevelSetting> levelSettings;
    private List<GarbageSetting> garbageSettings;

    private void Awake()
    {
        levelSettings = new List<LevelSetting>();
        garbageSettings = new List<GarbageSetting>();
    }

    public void SaveGarbage() {
        int level = int.Parse(textLevel.text);
        GarbageSetting gs = new GarbageSetting();
        gs.Id = int.Parse(textId.text);
        //gs.StartPosition = int.Parse(textStartPositon.text);
        //gs.RunTime = float.Parse(textRunTime.text);
        //gs.Height = float.Parse(textHeight.text);
        //gs.StartTime = float.Parse(textStartTime.text);
        //gs.RunId = int.Parse(textRunId.text);
        //gs.Effect = int.Parse(textEffect.text);
        garbageSettings.Add(gs);
        if (levelSettings.Count == level)
        {
            levelSettings[level - 1].StartId = Mathf.Min(levelSettings[level - 1].StartId, gs.Id - 1);
            levelSettings[level - 1].EndId = Mathf.Max(levelSettings[level - 1].EndId, gs.Id - 1);
        }
        else {
            LevelSetting ls = new LevelSetting();
            ls.Id = level;
            ls.StartId = ls.EndId = gs.Id - 1;
            levelSettings.Add(ls);
        }
        textId.text = textStartPositon.text = textRunTime.text = textHeight.text =
            textStartTime.text = textRunId.text = textEffect.text = textLevel.text = "";
    }
    public void SubmitLevel() {
        main.GetComponent<Main>().levelSettings = levelSettings;
        main.GetComponent<Main>().garbageSettings = garbageSettings;
        Close();
    }

    public void Close() {
        gameObject.SetActive(false);
        gameStart.SetActive(true);
    }
}
