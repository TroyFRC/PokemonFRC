﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public Canvas canvas;
	public Button[] selectMoveButtons;

	public PokemonScript player1, player2;
	private HashSet<Move> player2AppliedMoves, player1AppliedMoves;
	private int player1SelectedMove, player2SelectedMove;

	private enum GameState{
		Player1StartSelect, Player1Selecting, Player1Move, Player1Recoil, Player1HealthChange,
		Player2StartSelect, Player2Selecting, Player2Move, Player2Recoil, Player2HealthChange,
		EnvironmentChange //when the guy is no longer grappled.
	}
	private GameState currState;

	// Use this for initialization
	void Start () {
		//Set up the applied Moves lists
		player1AppliedMoves = new HashSet<Move> ();
		player2AppliedMoves = new HashSet<Move> ();

		//both players have not selected a move
		player1SelectedMove = player2SelectedMove = -1;

		//At first, player 1 is selecting a move
		currState = GameState.Player1StartSelect;

		//setting up the buttons to tell us which move was pressed
		for (int i = 0; i < 6; i++) {
			selectMoveButtons [i].onClick.AddListener(delegate() { SelectMove(i); });
		}

		//show UI for player 1
		showMoves (1);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (currState);
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
			}
			break;
		case GameState.Player1Move:
			//This should show message for what move used, animate the attack and the hp decrease
			//we can use unity's animators to do this and just check when the the 
			//animator controller's state machine is at resting.

			break;
		}
	}

	/**
	 * Shows Select Move UI.
	 */ 
	public void showMoves(int playerNumber){
		canvas.gameObject.SetActive (true);
		PokemonScript currPlayer = (playerNumber == 1)? player1: player2;

		for (int i = 0; i < 6; i++) {
			Text txt = selectMoveButtons [i].GetComponentInChildren<Text> ();
			txt.text = currPlayer.moves [i].GetName ();
		}

	
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