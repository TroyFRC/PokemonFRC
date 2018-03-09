using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PokemonScript : MonoBehaviour {

	public enum Status{
		Disabled,
		Grappled,
		Autonomous,
		Tilted
	}

	public Move[] moves;
	public HashSet<Status> status;
	public int hp;

	public int MAX_HEALTH;
	public int attackStat;
	public int speedStat;


	// Use this for initialization
	void Start () {
		hp = MAX_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addStatus(Status st){
		status.Add (st);
	}
}
