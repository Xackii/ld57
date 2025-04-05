using UnityEngine;
using UnityEngine.UI;

public class button : initializable
{
    public Sprite not_clicked;
    public Sprite clicked;
    public bool isclicked = false;

    public virtual void on_click()
    {
        isclicked = !isclicked;
        if(isclicked)
        {
            gameObject.GetComponent<Image>().sprite = clicked;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = not_clicked;
        }
    }
}
