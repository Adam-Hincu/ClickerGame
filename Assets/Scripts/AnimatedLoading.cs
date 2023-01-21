using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class AnimatedLoading : MonoBehaviour
{
	public TMP_Text text;
	int dots;
	void Start()
	{
		dots = 0;
		StartCoroutine(AnimateDots());
	}
	private IEnumerator AnimateDots()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.3f);
			dots++;
			if (dots > 3)
			{
				dots = 0;
			}
			text.text = "Loading";
			for (int i = 0; i < dots; i++)
			{
				text.text += ".";
			}
		}
	}
}
