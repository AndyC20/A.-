using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    public Button start_button;

    void start(){
        Button start = start_button.GetComponent<Button>();
    }

    public void to_instruction(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Detail");
    }
}
