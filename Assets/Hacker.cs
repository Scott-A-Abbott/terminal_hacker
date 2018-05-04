using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu(){
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
		else if(input == "007"){
			Terminal.WriteLine("Please select a level Mr. Bond");
		}
		else Terminal.WriteLine("Please select a level");
	}
}
