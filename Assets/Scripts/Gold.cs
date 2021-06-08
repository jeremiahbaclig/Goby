using System.Collections;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    public TMP_Text text;
    
    public static int goldCount;
    private int maxGold = 99999;

    private void Start()
    {
        goldCount = int.Parse(text.GetComponent<TMP_Text>().text);

    }

    public static void ResetGoldCount()
    {
        goldCount = 0;
    }

    private void AddGold()
    {
        goldCount++;
        text.GetComponent<TMP_Text>().SetText(goldCount.ToString());
    }

    public void StartGold()
    {
        StartCoroutine("GoldCounter");
    }

    public IEnumerator GoldCounter()
    {
        while (goldCount < maxGold)
        {
            while (PauseMenu.isPaused)
            {
                yield return null;
            }

            AddGold();
            yield return new WaitForSecondsRealtime(3);
        }
    }

    public void InitializeGold(int amount)
    {
        goldCount = amount;
        text.GetComponent<TMP_Text>().SetText(goldCount.ToString());
    }
}
