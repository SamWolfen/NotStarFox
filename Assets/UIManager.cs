using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<TextComponentReference> TextValues = new List<TextComponentReference>();
    public List<BarReference> BarValues = new List<BarReference>();

    private void OnEnable()
    {
        StartCoroutine(UpdateTexts());
    }
    IEnumerator UpdateTexts()
    {
        while (true)
        {
            foreach (var text in TextValues)
            {
                text.Text.text = text.CompValue;
            }


            yield return new WaitForSeconds(0.5f);
        }
    }

    public void UpdateTextValue(string key, string value)
    {
        //probably ineffectient as hell but eh
       TextValues.Single(x => x.CompName == key).CompValue = value;
    }

    public void CreateTextValue(string key, string initialValue, Text textComp)
    {
        if(TextValues.Any(x => x.CompName == key))
        {
            throw new Exception("that already exists ya dummy. pick a new name. Maybe staple a guid to it or something");
        }

        TextValues.Add(new TextComponentReference() { CompName = key, CompValue = initialValue, Text = textComp });
    }

}

public class TextComponentReference
    {
    public Text Text;
    public string CompName;
    public string CompValue;    
}
public class BarReference
{
    public string CompName;
    public string CompValue;
}