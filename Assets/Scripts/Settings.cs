using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{ 
    [SerializeField] private int levelOnStart;
    [SerializeField] private int scoreForLevel;
    [SerializeField] private float secondsBeforeGameOverSceneLoad;
    
    void Awake()
    {
        GameManager.Instance.StartGame(secondsBeforeGameOverSceneLoad);
        GameStats.Instance.ResetStats(levelOnStart, scoreForLevel);
        Destroy(gameObject);
    }
}