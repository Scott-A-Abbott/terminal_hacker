using UnityEngine;

public class Hacker : MonoBehaviour {

	//Game configuration Data
	string[] level1Passwords = {"wifi", "router", "guest", "home", "user"};
	string[] level2Passwords = {"account", "checking", "mortgage", "numbers", "interest"};
	string[] level3Passwords = {"paratroopers", "bureaucracy", "washington", "counterterrorism", "administration"};

	//Game State
	int level;
	enum Screen {MainMenu, Password, Win};
	Screen currentScreen;
	string password;

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
		Terminal.WriteLine("Press 3 for The Pentagon\n");		
		Terminal.WriteLine("Input:");
	}

	void OnUserInput(string input){
		if(input == "menu" || input == "Menu"){
			ShowMainMenu();
		}
		else if (currentScreen == Screen.MainMenu){
			RunMainMenu(input);
		}
		else if (currentScreen == Screen.Password){
			CheckPassword(input);
		}
	}
	void RunMainMenu(string input){
		bool isValidLevel = (input == "1" || input == "2" || input == "3");
		if (isValidLevel){
			level = int.Parse(input);
			AskForPassword();
		}
		else if(input == "007"){ // easter egg
			Terminal.WriteLine("Please select a level Mr. Bond");
		}
		else Terminal.WriteLine("Please select a level");
	}

	void AskForPassword(){
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		SetRandomPassword();
		Terminal.WriteLine("Enter the password, hint: " + password.Anagram());
	}
	void SetRandomPassword(){
		int index;		
		switch (level){
			case 1:
				index = Random.Range(0, level1Passwords.Length);
				password = level1Passwords[index];
				break;
			case 2:
				index = Random.Range(0, level2Passwords.Length);			
				password = level2Passwords[index];
				break;
			case 3: 
				index = Random.Range(0, level3Passwords.Length);			
				password = level3Passwords[index];
				break;
			default: 
				Debug.LogError("Invalid level number!");
				break;
		}
	}
	void CheckPassword(string input){
		if (input == password){
			DisplayWinScreen();
		} else AskForPassword();
	}
	void DisplayWinScreen(){
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
	}
	void ShowLevelReward(){
		switch (level)
		{
			case 1:
				Terminal.WriteLine("Free internet for life!");
				Terminal.WriteLine(@"
                ()    ____  ()
\\    /\    //  ||  ||      ||
 \\  /  \  //   ||  ||----  ||
  \\/    \//    ||  ||      ||
");
				break;
			case 2:
				Terminal.WriteLine(@"
------------------------------------
|#(1)*UNITED STATES OF AMERICA*(1)#|
|#**          /===\   ********  **#|
|*# {G}      | ( ) |             #*|
|#*  ******  | /v\ |    O N E    *#|
|#(1)         \===/            (1)#|
|##=========ONE DOLLAR===========##|
------------------------------------
");
				Terminal.WriteLine("I'm Rich!!");				
				break;
			case 3:
				Terminal.WriteLine(@"
          _ ._  _ , _ ._
        (_ ' ( `  )_  .__)
      ( (  (    )   `)  ) _)
     (__ (_   (_ . _) _) ,__)
         `~~`\ ' . /`~~`
              ;   ;
              /   \
_____________/_ __ \_____________
");
				Terminal.WriteLine("FEEL MY POWER!!");
				break;
		}
	}
}
