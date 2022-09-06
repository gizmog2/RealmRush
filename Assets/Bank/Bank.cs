using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
	[SerializeField] int startingBalance = 150;
	int currentBallance;
	public int CurrentBalance{ get { return CurrentBalance;}}
   
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
	}
}
