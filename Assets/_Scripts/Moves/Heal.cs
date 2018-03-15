using UnityEngine;
using System.Collections;

[System.Serializable]
public class Heal : Move{
	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){
		ours.hp += 20;
		return null;
	}

	public override string getMostRecentMoveText(){
		return "used "+GetName() + "! 20 hp healed..";
	}

	public override string GetName(){
		return "Heal";
	}
}