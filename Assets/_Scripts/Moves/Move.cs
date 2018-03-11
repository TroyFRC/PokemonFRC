using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Move : MonoBehaviour {
	public abstract Effect ApplyMove (PokemonScript enemy, PokemonScript ours);
	public abstract string GetName ();
}