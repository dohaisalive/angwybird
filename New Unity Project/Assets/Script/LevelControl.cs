using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] string nextLevelName;

    Monster[] monsters;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (monstersAreDead())
            GotoNextLevel();
    }

    bool monstersAreDead()
    {
        foreach (var monster in monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }
        return true;
    }

    void GotoNextLevel()
    {
        //Debug.Log("Go to level " + nextLevelName);
        SceneManager.LoadScene(nextLevelName);

    }

    void OnEnable()
    {
        monsters = FindObjectsOfType<Monster>();
    }
}
