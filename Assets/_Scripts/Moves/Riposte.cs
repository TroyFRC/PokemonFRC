using UnityEngine;
using System.Collections;

[System.Serializable]
public class Riposte : Move{

	bool lastMoveSucceeded = false;
	string lastMoveOurName;

	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){

		lastMoveOurName = ours.pokemonName;

		if (ours.isStatus (PokemonScript.Status.Grappled)) {
			enemy.hp -= (int)(ours.getAttackStat() * 0.6);
			ours.removeStatus (PokemonScript.Status.Grappled);
			lastMoveSucceeded = true;

		} else {
			lastMoveSucceeded = false;
		}
		return null;
	}

	public override string getMostRecentMoveText(){
		if (lastMoveSucceeded)
			return "used " + GetName () + "! " + lastMoveOurName + " has escaped the grapple!";
		else
			return "used " + GetName () + "! But it failed";
	}

	public override string GetName(){
		return "All Natural";
	}
}
