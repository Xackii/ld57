using UnityEngine;
using UnityEngine.UIElements;

public class tickable : initializable
{
    void Update()
    {
        if(g == null) Init();
        if(g.game_paused) return;
        Tick();
    }
    public virtual void Tick()
    {

    }
}
