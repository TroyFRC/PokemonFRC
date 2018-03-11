using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PokemonScript : MonoBehaviour {

	[Flags]
	public enum Status{
		Disabled = 1,
		Grappled = 2,
		Autonomous = 4,
		Tilted = 8
	}
    
    public Move[] history;
	public Move[] moves;
	public Status status;
	public int hp;

	public int MAX_HEALTH;
	public int attackStat;
	public int speedStat;


	void Start () {
		hp = MAX_HEALTH;
	}


	public void applyStatus(Status st) {
		status |= st;
	}
    
    public void removeStatus(Status st) {
    	status &= ~st;
    }
    
    public bool isStatus(Status st) {
		//this is basically saying status - st != status
		//which is only true if st is inside status.
		return (status & ~st) != status;
    }
		
}
