using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPun
{
	[SerializeField]
	private GameObject playerPrefab;

	[SerializeField]
	private Transform[] spawnPoints;

	[SerializeField]
	private float playerSpacing;

	void Start()
	{
		if (PhotonNetwork.IsMasterClient)
		{
			PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[0].position, spawnPoints[0].rotation);
		}
		else
		{
			Vector3 secondPlayerPos = spawnPoints[1].position;
			secondPlayerPos.x += playerSpacing;
			PhotonNetwork.Instantiate(playerPrefab.name, secondPlayerPos, spawnPoints[1].rotation);
		}
	}
}
