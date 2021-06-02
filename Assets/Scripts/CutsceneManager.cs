using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public static int cutscene = 1;
    public static bool isCutscene = false;
    public PlayerCamera cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && cutscene == 2)
        {
            GameObject.Find("DialogueTrigger" + cutscene).SetActive(false);
            GameObject.Find("TriggerTwo").GetComponent<DialogueTrigger>().TriggerDialogue();
            cam.CutsceneTwo();
        }
        else if (collision.tag == "Player" && cutscene == 3)
        {
            GameObject.Find("DialogueTrigger" + cutscene).SetActive(false);
            GameObject.Find("TriggerThree").GetComponent<DialogueTrigger>().TriggerDialogue();
            cam.CutsceneThree();
            GameObject.Find("PlayerEarlyBoundary").SetActive(false);
        }
    }
}
