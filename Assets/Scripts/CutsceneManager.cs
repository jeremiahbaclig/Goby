﻿using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public static int cutscene = 1;
    public static bool isCutscene = false;
    public PlayerCamera cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && cutscene == 2)
        {
            Debug.Log("Calling cut 2");
            cam.CutsceneTwo();
        }
    }
}
