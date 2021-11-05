using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 500;

    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI bankText;

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateBankText();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBankText();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateBankText();

        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void UpdateBankText()
    {
        bankText.text = "Gold: " + currentBalance;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
