using UnityEngine;
using System.Collections;
using TMPro;
using Photon.Pun;

public class CPSCounter : MonoBehaviourPun
{
	[SerializeField]
	public float CPS;
	private int clicks;
	private float timer;

	[SerializeField]
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

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(CPS);
		}
		else
		{
			CPS = (float)stream.ReceiveNext();
		}
	}
}
