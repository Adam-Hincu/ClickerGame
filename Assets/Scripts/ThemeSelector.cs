using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Data
{
	public Color Camera;
	public Color ParticleSystem;
	public Color MainSquare;
	public Color CPS;
	public Color Counter;
	public Color Gap;
}

public class ThemeSelector : MonoBehaviour
{
	private Camera Camera;
	public ParticleSystem ParticleSystem;
	public SpriteRenderer MainSquare;
	public TMP_Text CPS;
	public TMP_Text Counter;
	public SpriteRenderer Gap;

	public Data[] dataArray;

	void Start()
	{
		SelectTheme();
	}

	void SelectTheme()
	{
		Camera = FindObjectOfType<Camera>();

		int randomIndex = Random.Range(0, dataArray.Length);
		Data selectedData = dataArray[randomIndex];

		Camera.backgroundColor = selectedData.Camera;
		ParticleSystem.startColor = selectedData.ParticleSystem;
		MainSquare.color = selectedData.MainSquare;
		CPS.color = selectedData.CPS;
		Counter.color = selectedData.Counter;
		Gap.color = selectedData.Gap;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.V))
		{
			SelectTheme();
		}
	}
}
