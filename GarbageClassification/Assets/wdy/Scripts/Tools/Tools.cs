using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools 
{
    public delegate void show();

    public static void StopPanel(show show) {
        GlobalData.GameStop.SetActive(true);
        show();
    }

    public static void ReStartGame(show show)
    {
        GlobalData.GameStop.SetActive(false);
        GlobalData.Game.SetActive(true);
        //GlobalData.Game.transform.SetAsLastSibling();
        show();
    }

    public static void ReStartGameFromEnd(show show)
    {
        GlobalData.GameSuccess.SetActive(false);
        GlobalData.Game.SetActive(true);
        GlobalData.Game.transform.SetAsLastSibling();
        show();
    }

    public static void ReturnToOption(show show)
    {
        GlobalData.GameStop.SetActive(false);
        GlobalData.GameList.SetActive(true);
        GlobalData.GameList.transform.SetAsLastSibling();
        show();
    }

    public static void SuccessPanel(show show)
    {
        //GlobalData.Game.SetActive(false);
        GlobalData.GameSuccess.SetActive(true);
        //GlobalData.GameSuccess.transform.SetAsLastSibling();
        show();
    }
}
