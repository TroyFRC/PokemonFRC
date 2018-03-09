using UnityEngine;
using System.Collections;

[System.Serializable]
public class ThrowCubeMove : Move {
	public override void applyMove (PokemonScript enemy, PokemonScript ours){
		enemy.hp -= (int)(0.5 * ours.attackStat); 
	}

}
