using UnityEngine;
using System.Collections;
using TMPro;
using Photon.Pun;
using System;
using Unity.VisualScripting;

public class CPSCounter : MonoBehaviourPun
{
	public float CPS;
	public int CPS_int;
	private int clicks;
	private float timer;

	public TMP_Text text;

	public PlayfabManager playfabManager;
	public ClickCounter clickCounter;

	public int highCPS;

	private int currentClicks;
	private float currentTimer;

	private void Start()
	{
		text = GameObject.Find("Text (TMP) (1)").GetComponent<TMP_Text>();
		highCPS = 0;
	}

	void Update()
	{
		CPS_int = Mathf.RoundToInt(CPS);

		if (CPS_int >= highCPS)
		{
			highCPS = CPS_int;
		}

		if (clickCounter.win == true)
		{
			playfabManager.SendLeadBoard(highCPS);
		}

		text.text = "CPS : " + CPS.ToString();

		currentTimer += Time.deltaTime;
		if (Input.GetMouseButtonDown(0))
		{
			currentClicks++;
		}
		if (currentTimer >= 1)
		{
			CPS = currentClicks / currentTimer;
			CPS = Mathf.Round(CPS * 100f) / 100f;
			currentClicks = 0;
			currentTimer = 0;
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
