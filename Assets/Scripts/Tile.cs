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

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;

    public Sprite Sword;
    public Sprite Shield;




    private void OnMouseUp()
    {
        
        // Check for current player that is claiming ownership of this space
        owner = tileManager.CurrentPlayer;

        if (owner == TileManager.Owner.Sword)
            this.GetComponent<SpriteRenderer>().sprite = Sword;
        else if (owner == TileManager.Owner.Shield)
            this.GetComponent<SpriteRenderer>().sprite = Shield;

        // Update to the next player in rotation
        tileManager.ChangePlayer();


    }
}