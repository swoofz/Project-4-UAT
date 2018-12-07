using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public enum States { Idle, Walk, Jump, Attack };    // Create an enum for state changes

    public Pawn pawn;                                   // Create a variable to store what type of pawn is attached
    public float health, damageDo, speed, jumpForce;    // Create variables all classes that inheriet from controller
    public int jumpCount;                               // Create a variable to store how many times can jump
}
