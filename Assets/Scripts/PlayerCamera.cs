using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    public Animator camAnim;

    public GameObject stateCamera;

    private void Start()
    {
        stateCamera = GameObject.Find("CM StateDrivenCamera1");
    }

    public void CallOpening()
    {
        Invoke(nameof(OpeningCutscene), 0.2f);
    }

    public void OpeningCutscene()
    {
        camAnim.SetBool("OpeningCutscene", true);
        CutsceneManager.cutscene = 2;
        CutsceneManager.isCutscene = true;
        StartCoroutine(CallStopCutscene("OpeningCutscene", 0.5f));
    }

    IEnumerator CallStopCutscene(string name, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        StopCutscene(name);
    }

    public void CutsceneTwo()
    {
        camAnim.SetBool("CutsceneTwo", true);
        CutsceneManager.cutscene = 3;
        CutsceneManager.isCutscene = true;
        StartCoroutine(CallStopCutscene("CutsceneTwo", 2f));
    }

    private void StopCutscene(string cutsceneName)
    {
        camAnim.SetBool(cutsceneName, false);
        CutsceneManager.isCutscene = false;
    }
}
