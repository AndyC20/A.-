using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lose : MonoBehaviour
{
    public Button start_button;

    void start(){
        Button start = start_button.GetComponent<Button>();
    }

    public void game_restart(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Starting");
    }
}
