using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legacy : MonoBehaviour {

	public void ButtonOnClick(string parameters)
    {
        /* Once you need more then 1 parameter. Default unity will not show you your public
         * method. Thus only ask for a string parameter and in the funtion split it up.
         * Look example below. 
         */
        string[] splitPar = parameters.Split(","[0]); //gain string parameter and split eg. left, 3
        string direction = splitPar[0]; //assign to each variable to local one
        int lives = int.Parse(splitPar[1]);

        Debug.Log("Direction: " + direction + "\n Lives: " + lives);

        //Some logic
    }
}
