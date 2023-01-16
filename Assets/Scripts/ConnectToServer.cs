using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
	[SerializeField] private string SceneToLoad;
	private void Start()
	{
		PhotonNetwork.ConnectUsingSettings();
	}

	public override void OnConnectedToMaster()
	{
		SceneManager.LoadScene(SceneToLoad);
	}
}
