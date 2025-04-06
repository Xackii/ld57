using System;
using TMPro;
public class depth_text_ui : text_info
{
    TextMeshProUGUI depth_to_text;
    public override void Init()
    {
        depth_to_text = GetComponentInChildren<TextMeshProUGUI>();
        base.Init();
    }

    public override void update_text()
    {
        string generate_text = $"Depth {(int)MathF.Min(g.player_on_lvl, 4)}/{4}";
        depth_to_text.text = generate_text;
        base.update_text();
    }
}
