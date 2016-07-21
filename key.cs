using UnityEngine;
using System.Collections;

public class key : MonoBehaviour {
	//変数の定義
	public bool buttonInRange;
	public bool buttonActivated;
	public AudioClip kagi;
	public GameObject TheKey;
	private bool playerNextToKey = false;

	//Updateメソッド
	void Update () 
	{
		if (buttonInRange == true){
			if (Input.GetMouseButtonDown(0) && playerNextToKey == true)
			{
				AudioSource.PlayClipAtPoint(kagi, transform.position);
				TheKey.active = false;
			}
		}
	}
	//TriggerEnterメソッド
	void OnTriggerEnter (Collider theCollider)
	{
		buttonInRange = true;
		if (theCollider.tag == "Player")
		{
			playerNextToKey = true;
		}
	}
	//TriggerExitメソッド
	void OnTriggerExit (Collider theCollider)
	{
		buttonInRange = false;
		if (theCollider.tag == "Player")
		{
			playerNextToKey = false;
		}
	}
}