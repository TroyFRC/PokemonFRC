using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using System.Collections.Generic.IEnumerator<>;
using System.Collections.Generic;

public class PlayerSelectPokemonScript : MonoBehaviour {

	public int playerNumber;
	private ToggleGroup toggleGroup;


	// Use this for initialization
	void Start () {
		toggleGroup = GetComponent<ToggleGroup> ();
	}

	public string getSelection(){
		IEnumerator<Toggle> ienum = toggleGroup.ActiveToggles ().GetEnumerator ();
		ienum.MoveNext ();
		return ( ienum.Current.gameObject.GetComponentInChildren<Text>().text);
	}
}
