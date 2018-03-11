using UnityEngine;
using System.Collections;

[System.Serializable]
public class ElectricalStormMove : Move {
	
	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){
		enemy.hp -= (int)(0.5 * ours.attackStat); 
		return null;
	}

	public override string GetName(){
		return "Electrical Storm";
	}

}
