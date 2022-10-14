﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public struct DrivingActions {
	public float acc;
	public float steer;
}

public class DrivingAIScript : MonoBehaviour {
	public float accAmount = 0.2f;
	public float lookAhead = 0.4f;
	public float speedLookAhead = 0.3f;
	public float turnBraking = 2f;
	public float MinTurnBrakingSpeed = 2f;

	Tilemap traffic;
	Vector3 goal;
	DrivingScript driving;
	Rigidbody2D body;
	LayerMask carMask;
	float frontDist;
	float frontAxleDist;
	string lastDir;
	bool lastDirWasTurn;

	Dictionary<string, Vector3> dirVectors = new Dictionary<string, Vector3>() {
		{ "north", Vector3.up },
		{ "south", Vector3.down },
		{ "west", Vector3.left },
		{ "east", Vector3.right },
	};

	void Awake() {
		ConfigScript config = (ConfigScript)Object.FindObjectOfType(typeof(ConfigScript));

		traffic = GameObject.Find("Traffic").GetComponent<Tilemap>();
		driving = GetComponent<DrivingScript>();
		body = GetComponent<Rigidbody2D>();
		carMask = LayerMask.GetMask("Cars");

		frontDist = GetComponent<BoxCollider2D>().size.y / 2 + 0.1f; // front of car
		frontAxleDist = driving.wheelYoff / config.pixelsPerUnit; // front wheels
		Vector3 frontAxle = transform.position + transform.up * frontAxleDist;
		Vector3 cellCenter = traffic.CellToLocalInterpolated(traffic.WorldToCell(frontAxle) +
			new Vector3(0.5f, 0.5f, 0));
		goal = getNextCell(cellCenter);
	}

	public DrivingActions getDrivingActions() {
		Vector3 frontAxle = transform.position + transform.up * frontAxleDist;
		Vector3 goalDist = goal - frontAxle;

		while (goalDist.magnitude < lookAhead + body.velocity.magnitude * speedLookAhead) {
			Vector3 nextGoal = getNextCell(goal);
			if (nextGoal == goal) {
				break;
			}
			goal = nextGoal;
			goalDist = goal - frontAxle;
		}
		// Debug.DrawLine(frontAxle, goal, Color.red, Time.deltaTime);

		float thisAngleDiff = Vector3.SignedAngle(transform.up, goalDist, -transform.forward);
		float steer = Mathf.Clamp(thisAngleDiff / driving.maxWheelAngle, -1, 1);

		Vector3 front = transform.position + transform.up * frontDist;
		RaycastHit2D hit = Physics2D.Linecast(front, goal, carMask);

		Vector3 forwardVelocity = Vector3.Project(body.velocity, transform.up);
		float brake = Mathf.Abs(steer * turnBraking *
			Mathf.Max(0, ((forwardVelocity.magnitude - MinTurnBrakingSpeed) / MinTurnBrakingSpeed)));

		return new DrivingActions() {
			acc = hit ? 0 : accAmount * (1 - brake),
			steer = steer,
		};
	}

	Vector3 getNextCell(Vector3 currentCell) {
		TileBase currentTile = traffic.GetTile(traffic.WorldToCell(currentCell));
		if (currentTile == null || currentTile.name == null) {
			return currentCell;
		}
		string[] dirs = currentTile.name.Split(',');

		// Pick a direction at random from the dirs available on this tile.
		// Avoid taking two turns in a row if possible.
		// If a dir has a ! after it, it can only be taken if it matches the last dir.
		string dir;
		bool mustMatch;
		do {
			dir = dirs[Random.Range(0, dirs.Length)];
			mustMatch = dir.Contains("!");
			if (mustMatch) {
				dir = dir.Remove(dir.Length - 1);
			}
		}
		while ((dirs.Length > 1 && lastDirWasTurn && dir != lastDir) ||
			(mustMatch && dir != lastDir));

		lastDirWasTurn = lastDir != dir;
		lastDir = dir;
		return currentCell + dirVectors[dir];
	}
}
