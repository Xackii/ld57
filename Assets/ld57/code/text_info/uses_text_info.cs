using TMPro;
using UnityEngine;

public class uses_text_ui : text_info
{
    TextMeshProUGUI uses_to_text;
    public override void Init()
    {
        uses_to_text = GetComponentInChildren<TextMeshProUGUI>();
        base.Init();
    }

    public override void update_text()
    {
        string generate_text = $"{g.charges_we_have}";
        uses_to_text.text = generate_text;
        base.update_text();
    }
}
