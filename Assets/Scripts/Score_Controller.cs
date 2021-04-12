/*
Name: Nina Valdez
Student ID#: 2324247
Chapman email: divaldez@chapman.edu
Course Number and Section: 236-03
Assignment Number: 06 - Swords and Shields (AKA: Tic-Tac-Two-2x2 Unity)
This is my own work, and I did not cheat on this assignment.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Controller : MonoBehaviour

// Question 2: Score Counter 
{
    public int score = 0;

    public void UpdateSwordScore()
    {
        GetComponent<Text>().text = "Sword Score: " + score;
    }

    public void UpdateShieldScore()
    {
        GetComponent<Text>().text = "Shield Score: " + score;
    }
}