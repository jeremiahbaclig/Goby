using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Animator camAnim;
    public static bool starting = false;

    private void Update()
    {
        if (starting)
        {
            Debug.Log("Starting cutscene");
            CameraShake.Instance.ShakeCamera(4f, 0.15f);
            Invoke(nameof(OpeningCutscene), 0.02f);
        }
    }
    public void OpeningCutscene()
    {
        gameObject.SetActive(true);
        camAnim.SetBool("OpeningCutscene", true);
        StopCutscene();
    }

    private void StopCutscene()
    {
        camAnim.SetBool("OpeningCutscene", false);
        starting = false;
        gameObject.SetActive(false);
    }
}
