using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;

    private void Awake()
    {
        texture2D = Resources.Load<Texture2D>("Default");
    }
    void Start()
    {
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);

        EnableMode();
    }


    public void DisableMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EnableMode()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

   
}
