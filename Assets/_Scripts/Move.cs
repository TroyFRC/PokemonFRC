using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Move {
	public abstract void applyMove (PokemonScript enemy, PokemonScript ours);

}
