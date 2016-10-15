using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

    private static CursorScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
    }
}
