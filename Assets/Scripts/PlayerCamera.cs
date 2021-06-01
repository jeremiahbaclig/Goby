using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Animator camAnim;
    public static bool starting = false;

    private void Update()
    {
        if (starting)
        {
            CameraShake.Instance.ShakeCamera(4f, 0.15f);
            Invoke(nameof(OpeningCutscene), 0.02f);
        }
    }
    private void OpeningCutscene()
    {
        camAnim.SetBool("OpeningCutscene", true);
        Invoke(nameof(StopCutscene), 0.2f);
    }

    private void StopCutscene()
    {
        camAnim.SetBool("OpeningCutscene", false);
        starting = false;
        gameObject.SetActive(false);
    }
}
