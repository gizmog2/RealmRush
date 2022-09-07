using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
	[SerializeField] int startingBalance = 150;
	[SerializeField] int currentBallance;
	public int CurrentBalance{ get { return currentBallance;}}
   
	void Awake()
	{
		currentBallance = startingBalance;
	}
	
	
   
	public void Deposit(int amount)
	{
		currentBallance += Mathf.Abs(amount);
	}
	
	public void Withdraw(int amount)
	{
		currentBallance -= Mathf.Abs(amount);

		if (currentBallance < 0)
		{
			//Loss the game;
			ReloadScene();
		}
	}
	void ReloadScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);

		/*Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(currentScene.buildIndex);*/
	}
}
