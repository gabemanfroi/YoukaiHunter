using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject panel;
    public Button[] upgradeButtons;
    public PlayerUpgrades playerUpgrades;

    private string[] allUpgrades = { "AttackSpeed", "MoveSpeed", "ProjectileCount" };

    void Start()
    {
        panel.SetActive(false);
    }

    public void ShowUpgradeChoices()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;

        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            string upgrade = allUpgrades[Random.Range(0, allUpgrades.Length)];

            upgradeButtons[i].GetComponentInChildren<TMP_Text>().text = upgrade;

            upgradeButtons[i].onClick.RemoveAllListeners();
            upgradeButtons[i].onClick.AddListener(() => SelectUpgrade(upgrade));
        }
    }

    public void SelectUpgrade(string upgrade)
    {
        Debug.Log("Escolheu upgrade: " + upgrade);
        playerUpgrades.ApplyUpgrade(upgrade);

        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}