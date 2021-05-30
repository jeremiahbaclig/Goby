using UnityEngine;

public class Health : MonoBehaviour
{
    public static void RemoveHeart(int health)
    {
        Debug.Log(GameObject.Find("Health/heart" + health));
        GameObject.Find("Health/heart" + health).SetActive(false);
    }
}
