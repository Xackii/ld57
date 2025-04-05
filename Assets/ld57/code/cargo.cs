using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class cargo : initializable
{
    public List<cargo_slot> slots;
    public List<collectable> slots_filled_with = new List<collectable>();
    public fill_cargo fc;

    public override void Init()
    {
        fc = FindAnyObjectByType<fill_cargo>();
        base.Init();
    }
}
