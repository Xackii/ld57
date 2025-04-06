using TMPro;
using UnityEngine;

public class money_text_ui : text_info
{
    TextMeshProUGUI money_to_text;
    public override void Init()
    {
        money_to_text = GetComponentInChildren<TextMeshProUGUI>();
        base.Init();
    }

    public override void update_text()
    {
        string generate_text = $"{g.money}";
        money_to_text.text = generate_text;
        base.update_text();
    }
}
