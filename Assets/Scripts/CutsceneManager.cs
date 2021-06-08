using UnityEngine;
using Cinemachine;

public class CutsceneManager : MonoBehaviour
{
    public static int cutscene = 1;
    public static bool isCutscene = false;
    
    public PlayerCamera cam;
    public Gold gold;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && cutscene == 2)
        {
            GameObject.Find("DialogueTrigger" + cutscene).SetActive(false);
            GameObject.Find("TriggerTwo").GetComponent<DialogueTrigger>().TriggerDialogue();
            cam.CutsceneTwo();

            gold.InitializeGold(50);
        }
        else if (collision.tag == "Player" && cutscene == 3)
        {
            GameObject.Find("DialogueTrigger" + cutscene).SetActive(false);
            GameObject.Find("TriggerThree").GetComponent<DialogueTrigger>().TriggerDialogue();

            cam.CutsceneThree();

            GameObject.Find("PlayerEarlyBoundary").SetActive(false);

            gold.StartGold();
        }
    }
}
