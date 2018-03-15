using UnityEngine;
using System.Collections;

[System.Serializable]
public class WinchWhip : Move{
	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){
		enemy.hp -= (int) (0.4*ours.getAttackStat());
		return null;
	}
		

	public override string GetName(){
		return "Winch Whip";
	}
}
