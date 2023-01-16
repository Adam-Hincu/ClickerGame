using System.Collections;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
	public float shakeDuration = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	Vector3 originalPos;

	void OnEnable()
	{
		originalPos = transform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			transform.localPosition = originalPos;
		}
	}

	public void Shake(float duration, float amount)
	{
		shakeDuration = duration;
		shakeAmount = amount;
	}
}
