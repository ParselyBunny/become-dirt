using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontSwitcher : MonoBehaviour
{
    public List<TextMeshProUGUI> TextItemsBig;
    public List<TextMeshProUGUI> TextItemsDefault;

    public TMP_FontAsset Fancy_Big;

    public TMP_FontAsset Fancy_Default;

    public TMP_FontAsset Legible_Big;

    public TMP_FontAsset Legible_Default;


    // Start is called before the first frame update
    void Start()
    {
        foreach (TextMeshProUGUI text in Resources.FindObjectsOfTypeAll(typeof(TextMeshProUGUI)))
        {
            if (text.font == Fancy_Big || text.font == Legible_Big)
            {
                TextItemsBig.Add(text);
            }

            if (text.font == Fancy_Default || text.font == Legible_Default)
            {
                TextItemsDefault.Add(text);
            }
        }

    }

    public void switchStyle(Boolean fancy)
    {
        if (fancy)
        {
            foreach (TextMeshProUGUI big in TextItemsBig)
            {
                big.font = Fancy_Big;
            }

            foreach (TextMeshProUGUI def in TextItemsDefault)
            {
                def.font = Fancy_Default;
            }
        }
        else
        {
            foreach (TextMeshProUGUI big in TextItemsBig)
            {
                big.font = Legible_Big;
            }

            foreach (TextMeshProUGUI def in TextItemsDefault)
            {
                def.font = Legible_Default;
            }
        }
    }
}
