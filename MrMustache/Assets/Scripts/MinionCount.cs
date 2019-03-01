using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCount : MonoBehaviour {

    GameObject[] minions;
    static int numOfMinions;
    static int deadMinions;
    static int savedMinions;
    // Use this for initialization
    void Start()
    {
        minions = GameObject.FindGameObjectsWithTag("Minion");
        numOfMinions = minions.Length;
        Debug.Log(numOfMinions);
        deadMinions = 0;
        savedMinions = 0;
    }

    private void Update()
    {
        levelFinished();
    }

    public static void killMinion()
    {
        deadMinions++;
    }

    public static void saveMinion()
    {
        savedMinions++;
    }

    public static int getMinionCount()
    {
        return savedMinions;
    }

    public void levelFinished()
    {
        if(deadMinions + savedMinions == numOfMinions)
            GameManager.PlayGame();
    }
}
