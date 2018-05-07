using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
	//Game State
	int level;
	enum Screen {MainMenu, Password, Win};
	Screen currentScreen;

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu(){
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("Where should we begin?\n");
		Terminal.WriteLine("Press 1 for Neighbor's Wifi");
		Terminal.WriteLine("Press 2 for The National Bank");
		Terminal.WriteLine("Press 2 for The Pentagon\n");		
		Terminal.WriteLine("Input:");
	}

	void OnUserInput(string input){
		if(input == "menu" || input == "Menu"){
			ShowMainMenu();
		}
		else if (currentScreen == Screen.MainMenu){
			RunMainMenu(input);
		}
	}
	void RunMainMenu(string input){
		if(input == "1"){
			level = 1;
			StartGame();
		}
		else if(input == "2"){
			level = 2;
			StartGame();
		}
		else if(input == "007"){
			Terminal.WriteLine("Please select a level Mr. Bond");
		}
		else Terminal.WriteLine("Please select a level");
		}

	void StartGame(){
		currentScreen = Screen.Password;					
		Terminal.WriteLine("You have chosen level " + level);
	}
}
