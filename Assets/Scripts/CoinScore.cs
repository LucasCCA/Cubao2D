using UnityEngine;
using TMPro;

public class CoinScore : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinText;

    void Update()
    {
        coinText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
    }
}
