using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
	public Animator animator;
	public string Animation_Open;
	public string Animation_Close;

	public bool isOpen;

	private void Start()
	{
		isOpen = false;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && isOpen == false)
		{
			animator.Play(Animation_Open);

			isOpen = true;
		}

		if(Input.GetKeyDown(KeyCode.Escape) && isOpen == true)
		{
			Cancel();
		}
	}

	public void ExitButton()
	{
		SceneManager.LoadScene("Loading-Screen");
	}

	public void Cancel()
	{
		animator.Play(Animation_Close);

		isOpen = false;
	}
}
