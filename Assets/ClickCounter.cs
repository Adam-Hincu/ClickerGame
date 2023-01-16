using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using System;
using Unity.VisualScripting;

public class ClickCounter : MonoBehaviour
{
	[SerializeField] private TMP_Text text;

	[SerializeField] private GameObject Gap;

	[SerializeField] private float GapAmount;

	private int score;
	private float pitch = 1;

	[SerializeField] private Animator animator;

	[SerializeField] private ShakeScript shakeScript;

	[SerializeField] private ParticleSystem particleSystem;

	[SerializeField] private AudioSource Click;
	[SerializeField] private AudioSource plus5;
	[SerializeField] private AudioSource Win;


	private void OnMouseDown()
	{
		pitch += 0.01f;
		if (score >= 99)
		{
			shakeScript.Shake(0.5f, 0.089f);
			text.text = "Victory!";
			text.fontSize = 0.52f;

			Win.Play();
		}
		else
		{
			Gap.transform.localScale += new Vector3(GapAmount, GapAmount, 0);
			score++;
			if (UnityEngine.Random.value < 0.01f)
			{
				score += 5;

				particleSystem.Emit(15);

				plus5.Play();

				shakeScript.Shake(0.5f, 0.089f);
			}
			text.text = score.ToString();

			shakeScript.Shake(0.1f, 0.04f);

			particleSystem.Emit(3);

			animator.Play("PlayerRecoil");

			Click.Play();
			Click.pitch = pitch;
		}
	}

}