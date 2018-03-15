using UnityEngine;
using System.Collections;

[System.Serializable]
public class RevEngine : Move{

	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){
		
		// +5 speed for 2 turns ;;;;;;
		return null;

	}

	public override string getMostRecentMoveText(){
		return "TODO";
	}

	public override string GetName(){
		return "Reve Engine";
	}
}

