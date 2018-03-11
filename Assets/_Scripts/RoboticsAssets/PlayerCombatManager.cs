using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatManager : MonoBehaviour {
    private bool isDelayed = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void createDelay(int delay)
    {
        delayFalse();
        int temp = 0;
        while(temp < delay)
        {
            temp++;
        }
        isDelayed = true;
    }

    public void delayFalse()
    {
        isDelayed = false;
    }
}
