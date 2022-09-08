using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
	[SerializeField] int startingBalance = 150;
	[SerializeField] int currentBallance;
	[SerializeField] TextMeshProUGUI balanceText;
	public int CurrentBalance{ get { return currentBallance;}}
   
	void Awake()
	{
		currentBallance = startingBalance;
        DisplayText();
    }

	/*private void Start()
	{
		balanceText = GetComponent<TextMeshProUGUI>();
		DisplayText();
		
	}*/



	public void Deposit(int amount)
	{
		currentBallance += Mathf.Abs(amount);
        DisplayText();
    }
	
	public void Withdraw(int amount)
	{
		currentBallance -= Mathf.Abs(amount);
        DisplayText();

        if (currentBallance < 0)
		{
			//Loss the game;
			ReloadScene();
		}
	}

	void DisplayText()
	{
        balanceText.text = "Gold: " + currentBallance;
    }
	void ReloadScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);

		/*Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(currentScene.buildIndex);*/
	}
}
