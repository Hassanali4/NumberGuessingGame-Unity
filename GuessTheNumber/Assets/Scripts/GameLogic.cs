using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    //A variable type for the input field that is into the Unitys Canvas and used to take input from the user
    public InputField userInput;

    //A variable type for the Text field that is into the Unitys Canvas and displaayed to user when the game runs in green color
    public Text gameLabel;

    //A variable type for the Button field that is into the Unity's Canvas and displaayed to user when the game runs in whit colored
    public Button guesButton;

    //minimum & maximum variables of int type to used in the code
    public int min, max;
    private bool IsWon = false;// To check if the player has won the game or not

    //declaring a variable
    //private is an access modifier - makes this variable  only
    //accessible from this script
    private int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        ResetGameState();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick()
    {
        //Getting the users Inputed value from input field 
        //into a string type variable
        string userInputValue = userInput.text;

        //if the user does not enter anything then there will be a empyty input parsing into string error
        //to solve that error we will make an if to stop the empty input conversion into a string which is impossible
        if (userInputValue != "")
        {
            //converting that users input value string into an integer
            int answer = int.Parse(userInputValue);

            if (answer == randomNum)
            {
                gameLabel.text = "Correct";
                Debug.Log("Correct");
                //guesButton.interactable = false;
                IsWon = true;
                ResetGameState();
            }
            else if (answer > randomNum)
            {
                gameLabel.text = "Try Lower Number";
                Debug.Log("Try Lower Number");
            }
            else
            {
                gameLabel.text = "Try a higer Number";
                Debug.Log("Try a higer Number");
            }
        }
        else
        {
            gameLabel.text = "Please enter a Number!";
            Debug.Log("Please enter a Number!");
        }



        //Multiplying the users input value converted into an integer by 
        /*
                //Displaying the Multiplyed by users input value into console
                Debug.Log(" Twice what you entered is this " + answer);

                //Displaying the users input to console
                Debug.Log(userInput.text);
                //This is concatination - a series of interconnected things
                Debug.Log("This RandomNumber is " + randomNum);
        */
    }// Button Click Method

    private int GetRandomNumber(int min, int max)
    {
        int randomNumber = Random.Range(min,max);
        return randomNumber;
    }// Get Random Number Method
    public void ResetGameState()
    {
        if(IsWon)
        {
            min = Random.Range(0, 100);
            max = Random.Range(0, 100);
            gameLabel.text = "You Won !!! , Now Guess the Number Between " + min + " and " + (max - 1) + " ...";
            IsWon = false;
        }else
        {
            gameLabel.text = "Guess the Number Between " + min + " and " + (max - 1) + " ...";
        }
        //initializing the randNum variable
        randomNum = GetRandomNumber(min, max);
        max += 1;
    }

}
