using UnityEngine;
using System.Collections;

[System.Serializable]
public class AllNatural : Move{
	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){
		ours.hp += 10;
		return null;
	}

	public override string getMostRecentMoveText(){
		return "used "+GetName() + "! 10 hp healed";
	}

	public override string GetName(){
		return "All Natural";
	}
}