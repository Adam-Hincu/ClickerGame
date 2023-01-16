using UnityEngine;
using TMPro;

public class ThemeSelector : MonoBehaviour
{
	public Camera camera;
	public GameObject Cube;
	public GameObject Gap;
	public TMP_Text text;
	public ParticleSystem particles;

	public Color particleColor;

	private void Start()
	{
		ChangeColors();
	}

	public void ChangeColors()
	{
		camera.backgroundColor = new Color(2, 110, 129);
		Cube.GetComponent<Renderer>().material.color = new Color(2, 110, 129);
		Gap.GetComponent<Renderer>().material.color = new Color(2, 110, 129);
		text.color = new Color(2, 110, 129);
		var main = particles.main;
		main.startColor = particleColor;
	}
}
