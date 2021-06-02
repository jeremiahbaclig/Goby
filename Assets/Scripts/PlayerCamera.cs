using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    public Animator camAnim;

    public void OpeningCutscene()
    {
        GameObject.Find("CM StateDrivenCamera1").SetActive(true);
        camAnim.SetBool("OpeningCutscene", true);
        StopCutscene();
    }

    private void StopCutscene()
    {
        camAnim.SetBool("OpeningCutscene", false);
        GameObject.Find("CM StateDrivenCamera1").SetActive(false);
    }
}
