using UnityEngine;

public class Health : MonoBehaviour
{

    public GameObject player;
    private GameObject child;

    public void RemoveHeart(int health)
    {
        child = player.transform.Find("Health/heart" + health).gameObject;

        if (child)
        {
            child.SetActive(false);
        }      
    }
}
