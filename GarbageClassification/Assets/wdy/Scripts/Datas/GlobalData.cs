using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData 
{
    public static bool Left;//左边的按键是否被按下
    public static bool Mid;//中间的按键是否被按下
    public static bool Right;//右边的按键是否被按下

    public static int UseAllTime;//本局游戏所花费的整体时间（只计算操作时间）
    public static int LeastTime;//历史所用的最少时间
    public static int ChangeTime ;//图片已经改变了几次
    public static int MaxChangeTime = 7;//一共需要改变几次
    public static int Grade;//这次游戏的评级
    public static GameObject Game;//所开始的是哪款游戏
    public static GameObject GameList;
    public static GameObject GameStop;
    public static GameObject GameSuccess;
    public static string ShowText;

    public static string ScorePath;
    public static List<int> AllScores = new List<int>();
}
