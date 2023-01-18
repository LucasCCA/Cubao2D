using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("Item Info")]
    [SerializeField]
    private int price;

    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private GameObject textGO;

    [SerializeField]
    private Color skinColor;

    private string itemName;

    private bool owned = false;

    private bool equipped = false;

    [Header("Player")]
    [SerializeField]
    private GameObject player;

    void Start()
    {
        itemName = gameObject.name;

        if (itemName == "Default Skin" && !PlayerPrefs.HasKey("Default Skin"))
        {
            PlayerPrefs.SetInt("Default Skin", 3);
        }

        if (PlayerPrefs.GetInt(itemName, 1) == 1)
        {
            owned = false;
            equipped = false;
        }
        else if (PlayerPrefs.GetInt(itemName, 1) == 2)
        {
            owned = true;
            equipped = false;
        }
        else if (PlayerPrefs.GetInt(itemName, 1) == 3)
        {
            owned = true;
            equipped = true;
        }
    }

    void Update()
    {
        text.text = price.ToString();
        transform.GetChild(0).GetComponent<Image>().color = skinColor;

        if (equipped)
        {
            player.GetComponent<SpriteRenderer>().color = skinColor;
            textGO.SetActive(true);
            textGO.transform.GetChild(0).gameObject.SetActive(false);
            text.text = "Equipped";
            text.fontSize = 18f;
        }
        else
        {
            if (owned)
            {
                textGO.SetActive(false);
            }
        }
    }

    public void OnClick()
    {
        if (!owned)
        {
            Buy();
        }
        else
        {
            Equip();
        }
    }

    void Buy()
    {
        if (PlayerPrefs.GetInt("CoinCount", 0) >= price)
        {
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) - price);
            PlayerPrefs.SetInt(itemName, 2);
            owned = true;
        }
    }

    void Equip()
    {
        ShopItem[] shopItemScripts = FindObjectsOfType<ShopItem>();
        foreach (ShopItem shopItemScript in shopItemScripts)
        {
            if (shopItemScript.equipped)
            {
                PlayerPrefs.SetInt(shopItemScript.itemName, 2);
                shopItemScript.equipped = false;
            }
        }

        PlayerPrefs.SetInt(itemName, 3);
        equipped = true;
    }
}
