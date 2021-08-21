using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false; // 198
        Cursor.lockState = CursorLockMode.None; // unlock the cursor
        Cursor.visible = true; // make the cursor visible
    }
}
