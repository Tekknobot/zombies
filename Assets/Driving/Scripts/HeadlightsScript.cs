﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlightsScript : MonoBehaviour {
	public GameObject headlightPrefab;
	public float xOffset = 9;
	public float yOffset = 27;
	public float angle = 10;
	public bool startOn = true;

	float ppu;
	DrivingScript driving;
	GameObject[] headlights;

	void Start () {
		ConfigScript config = (ConfigScript)Object.FindObjectOfType(typeof(ConfigScript));
		ppu = 16;

		driving = GetComponent<DrivingScript>();

		headlights = new GameObject[] {
			addHeadlight(true),
			addHeadlight(false),
		};
		foreach (GameObject light in headlights) {
			light.SetActive(startOn);
		}
	}

	GameObject addHeadlight(bool flipX) {
		GameObject headlight = (GameObject)Instantiate(headlightPrefab, transform);
		headlight.transform.localPosition +=
			new Vector3(xOffset * (flipX ? -1 : 1) / ppu, yOffset / ppu, 0);

		return headlight;
	}

	void Update() {
		if (driving.playerControlled && Input.GetButtonDown("Fire1")) {
			foreach (GameObject light in headlights) {
				light.SetActive(!light.activeSelf);
			}
		}
	}
}
