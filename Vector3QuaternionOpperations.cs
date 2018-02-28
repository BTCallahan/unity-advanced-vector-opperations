using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3QuaternionOpperations {

	static public float silverRatio = 1f / Mathf.Sqrt(2f);

	static public Vector3 upRight = new Vector3(silverRatio,silverRatio), downRight=new Vector3(silverRatio,-silverRatio),downLeft=new Vector3(-silverRatio,-silverRatio),upLeft=new Vector3(-silverRatio,silverRatio),
	fowardRight = new Vector3(silverRatio,0f, silverRatio), backwardsRight=new Vector3(silverRatio,0f,-silverRatio), backwardsLeft=new Vector3(-silverRatio,0f,-silverRatio),fowardLeft=new Vector3(-silverRatio,0f,silverRatio);

	static public Vector3 RotateVector3_90Degrees(Vector3 vec, string axisToRotateAround, bool counterClockwise){

		switch (axisToRotateAround) {

		case "x":
		case "X":
		case "-x":
		case "-X":
			return counterClockwise ? new Vector3 (vec.x, vec.z, -vec.y) : new Vector3 (vec.x, -vec.z, vec.y);
		case "y":
		case "Y":
		case "-y":
		case "-Y":
			return counterClockwise ? new Vector3 (-vec.z, vec.y, vec.x) : new Vector3 (vec.z, vec.y, -vec.x);
		case "z":
		case "Z":
		case "-z":
		case "-Z":
			return counterClockwise ? new Vector3 (vec.y, -vec.x, vec.z) : new Vector3 (-vec.y, vec.x, vec.z);
		default:
			return vec;
		}
	}

	//Quaternion
	static public Vector3 RotateVector3(Vector3 vec, string axisToRotateAround, float degrees){

		Vector3 normedVec = vec.normalized;
		float mag = vec.magnitude;

		float sinedRads = Mathf.Sin (degrees * Mathf.Deg2Rad);
		float cosedRads = Mathf.Cos (degrees * Mathf.Deg2Rad);

		switch (axisToRotateAround) {

		case "x":
		case "X":
		case "-x":
		case "-X":
			return new Vector3 (normedVec.x, normedVec.y * cosedRads + normedVec.z * sinedRads, normedVec.z * cosedRads - normedVec.y * sinedRads) * mag;
		case "y":
		case "Y":
		case "-y":
		case "-Y":
			return new Vector3 (normedVec.x * cosedRads - normedVec.z * sinedRads, normedVec.y, normedVec.z * cosedRads + normedVec.x * sinedRads) * mag;
		case "z":
		case "Z":
		case "-z":
		case "-Z":
			return new Vector3 (normedVec.x * cosedRads - normedVec.y * sinedRads, normedVec.y * cosedRads + normedVec.x * sinedRads, normedVec.z) * mag;
		default:
			return Vector3.zero;
		}
	}

	static public Vector2 CircleTheSquare(Vector2 vec){

		float mag = vec.magnitude;

		Vector2 norm = vec.normalized;

		return new Vector2 (Mathf.Cos (silverRatio * norm.y) * norm.x, Mathf.Cos (silverRatio * norm.x) * norm.y);
	}

	static public Quaternion TrackPointAroundAxis(Vector3 origin, Vector3 target, string rotationAxis, string faceToAlignWithTarget, float factor=0f){

		Vector3 realitivePosition = (target - origin).normalized;

		float x = 0f, y = 0f, z = 0f, w = 1f;

		float rise = 1f, run = 1f;

		switch (rotationAxis) {
		case "y":
		case "Y":
			rise = realitivePosition.x;
			run = realitivePosition.z;

			switch (faceToAlignWithTarget) {
			case "z":
			case "Z":
				y = Mathf.Sin (0.5f * Mathf.Atan2 (rise, run));
				w = Mathf.Cos (0.5f * Mathf.Atan2 (rise, run));
				break;
			case "-z":
			case "-Z":
				y = Mathf.Cos (0.5f * Mathf.Atan2 (rise, run));
				w = -Mathf.Sin (0.5f * Mathf.Atan2 (rise, run));
				break;
			case "x":
			case "X":
				y = -Mathf.Sin (0.5f * Mathf.Atan2 (run, rise));
				w = Mathf.Cos (0.5f * Mathf.Atan2 (run, rise));
				break;
			case "-x":
			case "-X":
				y = Mathf.Cos (0.5f * Mathf.Atan2 (run, rise));
				w = Mathf.Sin (0.5f * Mathf.Atan2 (run, rise));
				break;
			default:
				break;
			}
			break;
		case "x":
		case "X":
			rise = realitivePosition.y;
			run = realitivePosition.z;

			switch (faceToAlignWithTarget) {
			case "z":
			case "Z":
				x = Mathf.Sin (0.5f * Mathf.Atan2 (rise, run));
				w = -Mathf.Cos (0.5f * Mathf.Atan2 (rise, run));
				break;
			case "-z":
			case "-Z":

				x = Mathf.Cos (0.5f * Mathf.Atan2 (rise, run));
				w = Mathf.Sin (0.5f * Mathf.Atan2 (rise, run));

				break;
			case "y":
			case "Y":
				x = Mathf.Sin (0.5f * Mathf.Atan2 (run, rise));
				w = Mathf.Cos (0.5f * Mathf.Atan2 (run, rise));
				break;
			case "-y":
			case "-Y":
				x = Mathf.Cos (0.5f * Mathf.Atan2 (run, rise));
				w = -Mathf.Sin (0.5f * Mathf.Atan2 (run, rise));
				break;
			default:
				break;
			}
			break;
		case "z":
		case "Z":
			rise = realitivePosition.x;
			run = realitivePosition.y;

			switch (faceToAlignWithTarget) {
			case "x":
			case "X":
				z = Mathf.Sin (0.5f * Mathf.Atan2 (run, rise));
				w = Mathf.Cos (0.5f * Mathf.Atan2 (run, rise));
				break;
			case "-x":
			case "-X":
				z = Mathf.Cos (0.5f * Mathf.Atan2 (run, rise));
				w = -Mathf.Sin (0.5f * Mathf.Atan2 (run, rise));
				break;
			case "y":
			case "Y":
				z = Mathf.Sin (0.5f * Mathf.Atan2 (rise, run));
				w = -Mathf.Cos (0.5f * Mathf.Atan2 (rise, run));
				break;
			case "-y":
			case "-Y":
				z = Mathf.Cos (0.5f * Mathf.Atan2 (rise, run));
				w = Mathf.Sin (0.5f * Mathf.Atan2 (rise, run));
				break;
			default:
				break;
			}
			break;
		default:
			break;
		}

		if (factor >= 1f) {

			float factorSquared = Mathf.Pow (factor, 2f);

			x = Mathf.Sin ((Mathf.Round (Mathf.Asin (x) * (factorSquared / Mathf.PI)) * Mathf.PI) / factorSquared);
			y = Mathf.Sin ((Mathf.Round (Mathf.Asin (y) * (factorSquared / Mathf.PI)) * Mathf.PI) / factorSquared);
			z = Mathf.Sin ((Mathf.Round (Mathf.Asin (z) * (factorSquared / Mathf.PI)) * Mathf.PI) / factorSquared);
			w = Mathf.Cos ((Mathf.Round (Mathf.Acos (w) * (factorSquared / Mathf.PI)) * Mathf.PI) / factorSquared);
		}
		return new Quaternion (x, y, z, w);
	}

	static public Quaternion ManualRotationOnAxis(string axis, float degrees){

		float x = 0f, y = 0f, z = 0f, w = 1f;

		switch (axis) {
		case "x":
		case "X":
		case "-x":
		case "-X":
			x = Mathf.Sin (degrees * 0.5f * Mathf.Deg2Rad);
			w = Mathf.Cos (degrees * 0.5f * Mathf.Deg2Rad);
			break;
		case "y":
		case "Y":
		case "-y":
		case "-Y":
			y = Mathf.Sin (degrees * 0.5f * Mathf.Deg2Rad);
			w = Mathf.Cos (degrees * 0.5f * Mathf.Deg2Rad);
			break;
		case "z":
		case "Z":
		case "-z":
		case "-Z":
			z = Mathf.Sin (degrees * 0.5f * Mathf.Deg2Rad);
			w = Mathf.Cos (degrees * 0.5f * Mathf.Deg2Rad);
			break;
		default:
			break;
		}

		return new Quaternion (x, y, z, w);
	}

}
