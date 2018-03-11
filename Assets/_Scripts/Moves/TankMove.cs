using UnityEngine;
using System.Collections;

[System.Serializable]
public class TankMove : Move { 
	public const float TANK_CONSTANT = 0.6f;
	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours){
		enemy.hp -= (int)((ours.MAX_HEALTH-ours.hp)*TANK_CONSTANT);
		ours.hp += (int)(0.5*(ours.MAX_HEALTH-ours.hp)*TANK_CONSTANT);
		return null;
	}

	public override string GetName(){
		return "Tank Move";
	}

}