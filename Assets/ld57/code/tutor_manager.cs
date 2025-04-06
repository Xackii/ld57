using System.Collections.Generic;
using UnityEngine;

public class tutor_manager : initializable
{
    private string[] tips = {
        "0",
        "Hey buddy, click on me to get next tip.",
        "It's your cargo.",
        "Collect boxes and store it here.",
        "It's your money.",
        "You will receive money by bringing boxes to the station.",
        "Box price is conveniently indicated in a large number on it",
        "It's your fuel charges.",
        "Start the engine to drive, turn it off to not drive.",
        "If you use up all your charges, you're finished.",
        "Rotate buttons to rotate.",
        "Don't crash into asteroids and planets.", 
        "Collect boxes to buy upgrades at the station",
        "The station is located above, you can't go wrong.",
        "go through 4 depths to reach the end",
        "Good Luck buddy!"
    };
    
    private int currentTipIndex = 0;

    public tutor_mascot mascot;

    public List<tutor_arrow> tutor_arrows = new List<tutor_arrow>();

    public override void Init()
    {
        foreach(tutor_arrow a in FindObjectsByType<tutor_arrow>(FindObjectsSortMode.None))
        {
            tutor_arrows.Add(a);
            a.gameObject.SetActive(false);
        }
        NextTip();
        base.Init();
    }
    public void NextTip()
    {
        if(currentTipIndex >= tips.Length - 1)
        {
            gameObject.SetActive(false);
            return;
        }

        foreach(tutor_arrow a in tutor_arrows)
        {
            if(a.id == currentTipIndex)
            {
                a.gameObject.SetActive(true);
            }
            else
            {
                a.gameObject.SetActive(false);
            }
        }

        currentTipIndex++;

        mascot.UpdateTip(tips[currentTipIndex]);
    }
}
