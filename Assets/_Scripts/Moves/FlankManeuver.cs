using UnityEngine;
using System.Collections;

[System.Serializable]
public class FlankManeuver : Move {
	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){
		ours.speedStat = (int)(1.2f * ours.speedStat); 
		return null;
	}

	public override string GetName(){
		return "Flank Maneuver";
	}
}