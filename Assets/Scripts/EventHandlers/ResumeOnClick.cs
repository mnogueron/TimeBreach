using UnityEngine;
using System.Collections;

public class ResumeOnClick : MonoBehaviour {

	public void Resume()
    {
        UIManager.HidePauseMenu();
        GameManager.Resume();
    }
}
