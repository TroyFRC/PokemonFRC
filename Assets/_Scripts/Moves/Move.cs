using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Move : MonoBehaviour {
	//format: [Pokemon Name] verb this thingy (no pokmeon name tho)
	//override if u want a custom move name.
	public virtual string getMostRecentMoveText(){
		return "used " + GetName() + "!";
	}
	public abstract Effect ApplyMove (PokemonScript enemy, PokemonScript ours);
	public abstract string GetName ();

	public bool passesProbability(float probabilityOfSuccess){
		float rand = Random.Range (0.0f, 1.0f);
		//check if its less than or if its equal.
		return rand < probabilityOfSuccess || Mathf.Abs ( rand- probabilityOfSuccess) < 0.001f;
	}
}