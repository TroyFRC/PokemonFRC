using UnityEngine;
using System.Collections;

[System.Serializable]
public class ClawGrab : Move{

	private PokemonScript enemyFromLastMove;

	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){
		enemy.hp -= (int)(0.8 * ours.getAttackStat()); //damage them
		enemy.applyStatus (PokemonScript.Status.Grappled); //grapple them
		enemyFromLastMove = enemy; //keep track of this for printing...
		return null;
	}

	public override string getMostRecentMoveText(){
		return "used "+GetName() + "! " + enemyFromLastMove.pokemonName + " is now grappled! ";
	}

	public override string GetName(){
		return "Claw Grab";
	}
}