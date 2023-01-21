using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
	public GameObject RowPrefab;
	public Transform rowsParent;

	private void Start()
	{
		Login();

		GetLeaderBoard();
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

	public void GetLeaderBoard()
	{
		var request = new GetLeaderboardRequest
		{
			StatisticName = "CPS",
			StartPosition = 0,
			MaxResultsCount = 99
		};
		PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
	}

	void OnLeaderboardGet(GetLeaderboardResult result)
	{
		foreach (Transform item in rowsParent)
		{
			Destroy(item.gameObject);
		}

		foreach (var item in result.Leaderboard)
		{
			GameObject newGo = Instantiate(RowPrefab, rowsParent);

			TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();

			texts[0].text = (item.Position + 1).ToString();
			texts[1].text = item.PlayFabId;
			texts[2].text = item.StatValue.ToString();

			Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
		}
	}
}
