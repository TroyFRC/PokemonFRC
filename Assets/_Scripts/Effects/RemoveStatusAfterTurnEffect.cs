using UnityEngine;
using System.Collections;

public class RemoveStatusAfterTurnEffect : Effect{
	private PokemonScript effectedBoi;
	private int turnsLeft;
	private PokemonScript.Status st;

	public RemoveStatusAfterTurnEffect(PokemonScript dude, int turns, PokemonScript.Status st){
		this.effectedBoi = dude;
		this.turnsLeft = turns;
		this.st = st;
	}


	public override bool ApplyEffect (){
		turnsLeft--;
		if (turnsLeft <= 0)
			effectedBoi.removeStatus (st);
		return turnsLeft <= 0;
	}
}
