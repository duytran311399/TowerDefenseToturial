using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public static int Zenny;
    public int startZenny = 400;

    private void Start()
    {
        Zenny = startZenny;
    }
}
