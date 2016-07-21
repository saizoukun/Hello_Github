using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	//変数の定義
	public GameObject key;
	private bool opened;
	private bool near;
	private Animator animator;
	public AudioClip open;
	public AudioClip akanai;

	//Startメソッド
	void Start () 
	{
		opened = false;
		near = false;
		animator = transform.parent.GetComponent<Animator>();
	}
	//Updateメソッド
	void Update () 
	{
		//開かない時のロジック
		if (Input.GetMouseButtonDown(0) && near && key.active == true){
			GetComponent<AudioSource>().PlayOneShot(akanai);
		}
		//開いた時のロジック
		if (Input.GetMouseButtonDown(0) && near  &&  key.active == false){
			if(!opened) {
				animator.SetBool("Open", true);
				GetComponent<AudioSource>().PlayOneShot(open);
				Open();
			}
		}
	}
	//TriggerEnterメソッド
	void OnTriggerEnter (Collider theCollider)
	{
		//Playerタグだったらnear変数をtrueにする
		if (theCollider.tag == "Player")
		{
			near = true;
		}
	}
	//TriggerExitメソッド
	void OnTriggerExit (Collider theCollider)
	{
		//Playerタグのオブジェクトが離れたらnearをfalseにする
		if (theCollider.tag == "Player")
		{
			near = false;
		}
	}
	//Openメソッド　反転させる
	void Open() {
		opened = !opened;
	}
}