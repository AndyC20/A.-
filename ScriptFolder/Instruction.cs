using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public Button start_button;

    void start(){
        Button start = start_button.GetComponent<Button>();
    }

    public void game_start(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("hunt");
    }
}
