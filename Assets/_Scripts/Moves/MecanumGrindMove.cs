using UnityEngine;
using System.Collections;

[System.Serializable]
public class MecanumGrindMove : Move {
	public override Effect ApplyMove (PokemonScript ours, PokemonScript enemy){

		int rand = Random.Range(1, 100);
		int choose =  Random.Range(1,2);
		if(rand <= 20)
		{
			if(choose == 1)
			{
				enemy.hp = 0;
			}
			else
			{
				ours.hp = 0;
			}
		}
		return null;
	}

	public override string GetName(){
		return "Mecanum Grind";
	}

}