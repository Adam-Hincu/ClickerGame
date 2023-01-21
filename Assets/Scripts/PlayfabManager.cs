using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
	private void Start()
	{
		Login();
	}

	void Login()
	{
		var request = new LoginWithCustomIDRequest()
		{
			CustomId = SystemInfo.deviceUniqueIdentifier,
			CreateAccount = true
		};
		PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
	}

	void OnSuccess(LoginResult result)
	{
		Debug.Log("Successful login/account create!");
	}

	void OnError(PlayFabError error)
	{
		Debug.Log("Error while logging in/creating account!");
		Debug.Log(error.GenerateErrorReport());
	}

	public void SendLeadBoard(int score)
	{
		var request = new UpdatePlayerStatisticsRequest
		{
			Statistics = new List<StatisticUpdate>
			{
				new StatisticUpdate
				{
					StatisticName = "CPS",

					Value = score
				}
			}
		};
		PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
	}

	void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
	{
		Debug.Log("Successfull leaderboard sent");
	}
}
