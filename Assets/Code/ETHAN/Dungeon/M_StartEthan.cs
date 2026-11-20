using Code.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M_StartEthan : Singleton<M_StartEthan>
{

    public void SwitchToGameScene()
    {
        SceneManager.LoadScene(1);
    }



}
