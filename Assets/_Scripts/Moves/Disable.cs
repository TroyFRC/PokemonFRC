using UnityEngine;
using System.Collections;

[System.Serializable]
public class Disable : Move{

	float probOfSucceeding = 1f;

	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){

		if (passesProbability (probOfSucceeding)) {
			enemy.applyStatus (PokemonScript.Status.Disabled);
			enemy.hp -= (int)(0.2 * ours.getAttackStat());
		}

		probOfSucceeding *= 3.0f / 4; //decrease the probability
		return new RemoveStatusAfterTurnEffect(enemy, 1, PokemonScript.Status.Disabled);
	}

	public override string getMostRecentMoveText(){
		return "used "+GetName() + "! 20 hp healed..";
	}

	public override string GetName(){
		return "Heal";
	}
}
