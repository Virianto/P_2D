using Code.Utils;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartEthan : Singleton<UI_StartEthan>
{
    [SerializeField] Button playButton;


    public void StartGame()
    {
        M_StartEthan.Instance.SwitchToGameScene();
    }


}
