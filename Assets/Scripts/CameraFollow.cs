using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public float CameraDistance;
	// Update is called once per frame

	void Update () {

		this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x - Time.deltaTime ,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		
	}

}
