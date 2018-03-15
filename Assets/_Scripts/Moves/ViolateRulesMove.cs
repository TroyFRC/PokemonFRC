using UnityEngine;
using System.Collections;

[System.Serializable]
public class ViolateRulesMove : Move{
	public override Effect ApplyMove (PokemonScript enemy, PokemonScript ours)
	{
		ours.hp = 0;
		return null;
	}

	public override string GetName(){
		return "Violate Rules";
	}
}
