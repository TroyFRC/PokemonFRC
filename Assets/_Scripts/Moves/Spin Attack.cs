using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpinAttack : Move{

	string lastMoveOurName;
	bool escapedGrapple;

	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){
		lastMoveOurName = ours.pokemonName;	
		escapedGrapple = ours.isStatus (PokemonScript.Status.Grappled);

		if (escapedGrapple) {
			enemy.hp -= (int)(0.7 * ours.getAttackStat());
		} else{
			enemy.hp -= (int)(0.2 * ours.getAttackStat());
		}

		return null;

	}

	public override string getMostRecentMoveText(){
		if(escapedGrapple)
			return "used "+GetName() + "! " + lastMoveOurName + " has escaped the grapple!";
		else
			return "used "+GetName() + "! ";
	}

	public override string GetName(){
		return "Heal";
	}
}