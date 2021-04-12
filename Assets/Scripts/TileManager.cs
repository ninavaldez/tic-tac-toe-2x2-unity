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

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    private Text swordScoreText;
    private Text shieldScoreText;

    public GameObject QuitButton;
    public GameObject ResetButton;

    public Sprite Tile_sprite;

    // Start is called before the first frame update
    void Start()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
        swordScoreText = GameObject.Find("SwordScore").GetComponent<Text>();
        shieldScoreText = GameObject.Find("SheildScore").GetComponent<Text>();

        // Question 4: Quit Game Application
        QuitButton.SetActive(false);

        // Question 3: (Count.) Reset Game (play another round w/o resetting score board)
        ResetButton.SetActive(false);
    }

    public void ChangePlayer()
    {
        if (CheckForWinner())
            return;

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    // Question 1: Modify 2x2 Grid into 3x3 Grid
    public bool CheckForWinner()
    {
        // First Row
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;

        // Second Row
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;

        // Third Row
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        // First Column
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;

        // Second Column
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;

        // Third Column
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        // Diagnol (Left to Right)
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        // Diagnol (Right to Left)
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            Debug.Log("Winner: " + CurrentPlayer);

            // Question 2: (Cont.) Updating Score in Game
            if (CurrentPlayer == Owner.Sword)
            {
                swordScoreText.GetComponent<Score_Controller>().score += 1;
                swordScoreText.GetComponent<Score_Controller>().UpdateSwordScore();
            }

            else if (CurrentPlayer == Owner.Shield)
            {
                shieldScoreText.GetComponent<Score_Controller>().score += 1;
                shieldScoreText.GetComponent<Score_Controller>().UpdateShieldScore();
            }

            // Question 4: (Count.) Quit Game Application
            QuitButton.SetActive(true);

            // Question 3: (Count.) Reset Game (play another round w/o resetting score board)
            ResetButton.SetActive(true);

            return true;
        }

        return false;
    }

    // Question 4: (Count.) Quit Game Application
    public void Quit()
    {
        Debug.Log("Game is Quitting... ");
        Application.Quit();
        Debug.Log("Game Quit - Goodbye! ");
    }

    // // Question 3: (Count.) Reset Game (play another round w/o resetting score board)
    public void Reset()
    {
        Debug.Log("Resetting Game! ");
        Start();

        for (int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i].GetComponent<SpriteRenderer>().sprite = Tile_sprite;
            Tiles[i].owner = Owner.None;


        }

    }





}
