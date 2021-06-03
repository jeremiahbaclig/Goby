using UnityEngine;

public class MobileCheck : MonoBehaviour
{
    public GameObject mobileButtons;
    private void Awake()
    {

#if UNITY_IOS || UNITY_ANDROID || UNITY_WP_8_1
        PlayerController.onMobile = true;
#endif

        if (PlayerController.onMobile)
        {
            mobileButtons = GameObject.Find("MobileButtons");
            mobileButtons.SetActive(true);
        }
        else
        {
            mobileButtons.SetActive(false);
        }
    }
}
