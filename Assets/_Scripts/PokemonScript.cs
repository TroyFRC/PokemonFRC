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
	private int attackStat;
	public int speedStat;
	public string pokemonName;


	void Start () {}

	public void Init(){
		hp = MAX_HEALTH;
		moves = GetComponents<Move> ();
		Debug.Log (moves.Length);
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
		

	//getters and setters for attackStat
	public int getAttackStat(){
		if (isStatus (Status.Grappled))
			return 20 + attackStat;    //TODO should this have max??
		return attackStat;
	}

	public void setAttackStat(int a){
		attackStat = a;
	}
		
}
