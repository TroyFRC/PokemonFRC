using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButtonScript : MonoBehaviour {

	public PlayerSelectPokemonScript player1Select, player2Select;
	private Button startGameButton;

	// Use this for initialization
	void Start () {
		startGameButton = GetComponent<Button> ();
		startGameButton.onClick.AddListener (onClick);
	}
	
	// Update is called once per frame
	void onClick(){
		GameManagerScript.player1PokemonSelection = player1Select.getSelection();
		GameManagerScript.player2PokemonSelection = player2Select.getSelection();

		Debug.Log ("started Next scene");
		SceneManager.LoadScene (1);
	}
}
