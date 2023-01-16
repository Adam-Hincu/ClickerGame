using UnityEngine;
using System.Collections;
using TMPro;
public class CPSCounter : MonoBehaviour
{
	public float CPS;
	private int clicks;
	private float timer;

	public TMP_Text text;

	void Update()
	{
		text.text = "CPS : " + CPS.ToString();

		timer += Time.deltaTime;
		if (Input.GetMouseButtonDown(0))
		{
			clicks++;
		}
		if (timer >= 1)
		{
			CPS = clicks / timer;
			CPS = Mathf.Round(CPS * 100f) / 100f;
			clicks = 0;
			timer = 0;
		}
	}
}
