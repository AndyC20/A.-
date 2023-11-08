using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public string LabelText = "Don't lose your way =)";
    public int maxItem = 10;
    private int itemsCollected = 0;
    // set timer time
    private bool run = false;
    private float Timer = 900.0f;

    void Start(){
        run = true;
        Timer = 900.0f;
    }

    void Update(){
        if(run){
            Timer -= Time.deltaTime; // allow the timer to count down

            if(Timer <= 0){
                Timer = 0; // set the timer to the timer to prevent it from going any further below
                run = false; // stops the timer when it reaches the timer set time
            }
        }
    }

    public int Items{
        get{return itemsCollected;}
        set{itemsCollected = value;
        if(itemsCollected >= maxItem){
            LabelText = "Congratulations... You found them all... :{";

        }
        else{
            LabelText = ".-. . -- . -- .. -. .. -. --." + (maxItem - itemsCollected);
        }
        }
    }

    public void OnGUI(){
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 100;
        myStyle.normal.textColor = Color.white;
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + itemsCollected, myStyle);
        GUI.Box(new Rect(20, 200, 150, 25), "Items Remaining: " + (maxItem - itemsCollected), myStyle);
        GUI.Label(new Rect(Screen.width*2/3, 50, 300, 50), LabelText, myStyle);

        int timeDown = (int)Timer; // change the time to int
        GUI.Box(new Rect(Screen.width/3, 100, 200, 50), "Time Left: " + timeDown.ToString(), myStyle); // display the countdown

        if (Timer == 0)
        {
            // When timer reach zero, it'll diaplay a end screen
            GUI.Label(new Rect(10, 60, 200, 50), "Time's up!");
        }
    }
}
