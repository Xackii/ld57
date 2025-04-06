using UnityEngine;

public class initializable : MonoBehaviour
{
    public game_controller g;
    public virtual void Init()
    {
        ///Debug.Log($"Initialized Component {this} in object {gameObject}");
    }
}
