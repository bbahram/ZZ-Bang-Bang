using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNum : MonoBehaviour
{
    [SerializeField] int zNum;
    SceneLoader nextScene;
    private void Start()
    {
        nextScene = FindObjectOfType<SceneLoader>();
    }
    public void ZCount()
    {
        zNum++;
    }
    public void ZombieKill()
    {
        zNum--;
        if(zNum==0)
        {
            nextScene.LoadNextScene();
        }
    }
}
