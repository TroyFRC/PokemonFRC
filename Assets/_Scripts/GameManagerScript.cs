using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System.Collections.Generic;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public static string player1PokemonSelection, player2PokemonSelection;
	public static Dictionary<string, Sprite> spritesDict;

	public GameObject selectMovePanel;
	public Button[] selectMoveButtons;

	public PokemonScript player1, player2;
	private List<Effect> player2AppliedEffects, player1AppliedEffects;
	private int player1SelectedMove, player2SelectedMove;

	private enum GameState{
		Player1StartSelect, Player1Selecting, Player1Move, Player1HealthChange,
		Player2StartSelect, Player2Selecting, Player2Move,  Player2HealthChange,
		EnvironmentChange //when the guy is no longer grappled, also applies Effects
	}
	private GameState currState;

	private Texter texter;
	public GameObject textingPanel;

	// Use this for initialization
	void Start () {
		//sprites
		string[] spriteNames = {"Celebi", "Gardevoir", "Name", "Wood Robot", "The Piston Claw Pummeler", "The Calculating Mech"};
		spritesDict = new Dictionary<string, Sprite> ();
		foreach (string spriteName in spriteNames) {
			spritesDict [spriteName] = Resources.Load <Sprite> ("Images/" + spriteName);
		}
	
		//set up Player 1 and player 2 using strings passed from previous scene
		CreatePokemonFromName(1, player1PokemonSelection);
		CreatePokemonFromName (2, player2PokemonSelection);
		player1.Init ();
		player2.Init ();

		texter = new Texter (textingPanel.GetComponentInChildren<Text> ());

		//Set up the applied Moves lists
		player1AppliedEffects = new List<Effect> ();
		player2AppliedEffects = new List<Effect> ();

		//both players have not selected a move
		player1SelectedMove = player2SelectedMove = -1;

		//At first, player 1 is selecting a move
		currState = GameState.Player1StartSelect;

		//setting up the buttons to tell us which move was pressed

		selectMoveButtons [0].onClick.AddListener(delegate() { SelectMove(0); });
		selectMoveButtons [1].onClick.AddListener(delegate() { SelectMove(1); });
		selectMoveButtons [2].onClick.AddListener(delegate() { SelectMove(2); });
		selectMoveButtons [3].onClick.AddListener(delegate() { SelectMove(3); });
		selectMoveButtons [4].onClick.AddListener(delegate() { SelectMove(4); });
		selectMoveButtons [5].onClick.AddListener(delegate() { SelectMove(5); });

		//show UI for player 1
		showMoves (1);
	}

	void CreatePokemonFromName(int playerNumber, string pokemonName){
		GameObject go = GameObject.Find ("Player" + playerNumber);
		PokemonScript ps = go.GetComponent<PokemonScript> ();
		SpriteRenderer sr = go.GetComponent<SpriteRenderer> ();
		Debug.Log (ps);
		//kills all moves that exist in it
		Move[] moves = go.GetComponents<Move> ();
		foreach (Move m in moves) {
			DestroyImmediate (m);
		}

		sr.sprite = spritesDict [pokemonName];
		ps.pokemonName = pokemonName;

		switch (pokemonName) {
		case "Celebi":
			ps.MAX_HEALTH = 30;
			ps.speedStat = 90;
			ps.setAttackStat(85);
			go.AddComponent<ClawGrab> ();
			go.AddComponent<ThrowCubeMove> ();
			go.AddComponent<FlankManeuver> ();
			go.AddComponent<WinchWhip> ();
			go.AddComponent<RevEngine> ();
			go.AddComponent<AllNatural> ();
			break;
		case "Gardevoir":
			ps.MAX_HEALTH = 150;
			ps.speedStat = 60;
			ps.setAttackStat(80);
			go.AddComponent<FlankManeuver> ();
			go.AddComponent<Disable> ();
			go.AddComponent<SpinAttack> ();
			go.AddComponent<WinchWhip> ();
			go.AddComponent<Riposte> ();
			go.AddComponent<Heal> ();
			break;
		}
		//TODO: finish set up for other pokemons
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Plyaer 1 selected " + player1SelectedMove);
		switch (currState) {
		case GameState.Player1StartSelect:
			//show UI for selecting move
			showMoves (1);

			//say that the player has not selected yet
			player1SelectedMove = -1;

			//switch states
			currState = GameState.Player1Selecting;
			break;
		case GameState.Player1Selecting:
			//this waits until the button listener SelectMove has set player1SelectedMove to something.
			if (player1SelectedMove != -1) {

				//switch states
				currState = GameState.Player2StartSelect;
			}
			break;
		case GameState.Player2StartSelect:
			//show UI for selecting move
			showMoves (2);

			//say that the player has not selected yet
			player2SelectedMove = -1;

			//switch states
			currState = GameState.Player2Selecting;
			break;
		case GameState.Player2Selecting:
			//this waits until the button listener SelectMove has set player2SelectedMove to something.
			if (player2SelectedMove != -1) {

				//switch states
				currState = GameState.Player1Move;
				hideMoves ();
			}
			break;
		case GameState.Player1Move:
			//animate the attack and the hp decrease
			//we can use unity's animators to do this and just check when the the 
			//animator controller's state machine is at resting.
			//This should show message for what move used
			if (ShowText (player1.pokemonName + " used " + player1.moves [player1SelectedMove].GetName () + "!")) {
				currState = GameState.Player2HealthChange;
				player1.animateAttack ();
				player2.animateRecoil ();
			}
			break;
		case GameState.Player2HealthChange:
			//This would change player2's health.
			break;
		
		}
	}

	/**
	 * Shows Select Move UI.
	 */ 
	public void showMoves(int playerNumber){
		selectMovePanel.SetActive (true);
		PokemonScript currPlayer = (playerNumber == 1)? player1: player2;

		for (int i = 0; i < 6; i++) {
			Text txt = selectMoveButtons [i].GetComponentInChildren<Text> ();
			txt.text = currPlayer.moves [i].GetName ();
		}
	}

	public void hideMoves(){
		selectMovePanel.SetActive (false);
	}

	public bool ShowText(string message){
		textingPanel.SetActive (true);
		texter.setText (message);
		return texter.TextTheString();
	}


	/**
	 * A listener for the buttons 
	 */ 
	void SelectMove(int moveIndex){
		if (currState == GameState.Player1Selecting) {
			player1SelectedMove = moveIndex;
		} else if (currState == GameState.Player2Selecting) {
			player2SelectedMove = moveIndex;
		}
			
	}
}
