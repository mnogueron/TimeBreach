using UnityEngine;
using System.Collections;

public class TextTimer : MonoBehaviour {

	// only one instance of the TextTimer can exist inside the game
	public static TextTimer instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public static IEnumerator SetTimeout(float time)
	{
		yield return new WaitForSeconds(time);
		instance.gameObject.SetActive (false);
	}


}
