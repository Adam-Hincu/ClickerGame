using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class EscMenu : MonoBehaviourPunCallbacks
{
	public static bool GameisPaused = false;

	public GameObject pauseMenuUI;

	public Animator animator;

	public Canvas canvas;

	private void Start()
	{
		GameisPaused = false;
		Resume();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(GameisPaused)
			{
				Resume();
			} else
			{
				Pause();
			}
		}

		if (photonView.IsMine)
		{
			canvas.enabled = true;
		}
		else
		{
			canvas.enabled = false;
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);

		GameisPaused = false;
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);

		GameisPaused = true;

		animator.Play("Animation_Open");
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Leave()
	{
		PhotonNetwork.Disconnect();

		PhotonNetwork.LoadLevel("Loading-Screen");
	}
}
