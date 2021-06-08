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
        CutsceneManager.isCutscene = true;
        StartCoroutine(CallStopCutscene("OpeningCutscene", 0.5f));
        CutsceneManager.cutscene = 2;
    }

    IEnumerator CallStopCutscene(string name, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        StopCutscene(name);
    }

    public void CutsceneTwo()
    {
        camAnim.SetBool("CutsceneTwo", true);
        CutsceneManager.isCutscene = true;
        StartCoroutine(CallStopCutscene("CutsceneTwo", 2f));
        CutsceneManager.cutscene = 3;
    }

    public void CutsceneThree()
    {
        camAnim.SetBool("CutsceneThree", true);
        CutsceneManager.isCutscene = true;
        StartCoroutine(CallStopCutscene("CutsceneThree", 2f));
        CutsceneManager.cutscene = 4;
    }

    private void StopCutscene(string cutsceneName)
    {
        camAnim.SetBool(cutsceneName, false);
        CutsceneManager.isCutscene = false;
    }
}
