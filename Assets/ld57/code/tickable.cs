using UnityEngine;
using UnityEngine.UIElements;

public class tickable : initializable
{
    void Update()
    {
        if(g.game_paused) return;
        Tick();
    }
    public virtual void Tick()
    {

    }
}
