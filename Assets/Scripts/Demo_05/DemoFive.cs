#pragma warning disable RECS0165

using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DemoFive : MonoBehaviour
{
    public Text List;
    public Text Dialog;
    private string _dialogText;
    private float _dialogSpeed = 100f;
    private WebClient _client = new WebClient();

    public async void DownloadRepos()
    {
        List.text = "loading...";
        // Just as a warning this is potentially a security problem with any HTTPS request.
        // Essentially this allows any SSL Certificate which defeats the purpose of HTTPS in the first place.
        // There are solutions online which I believe are the 'correct' way to fix this.
        // This problem only exists because unity uses such an old version of mono afaik.
        ServicePointManager.ServerCertificateValidationCallback += (a, b, c, d) => true;

        Logger.Log("Downloading HTML from Github");

        // Download the github page HTML
        var html = await _client.DownloadStringTaskAsync("http://github.com/Pima-GAM150");
        Logger.Log("Loaded HTML from Github");
        // HtmlAgilityPack class
        var doc = new HtmlDocument();

        doc.LoadHtml(html);

        // Select all <a> tags with the itemprop attribute with a value of "name codeRepository".
        var targetNodes = doc.DocumentNode.SelectNodes("//a[@itemprop]").Where(node => node.Attributes["itemprop"].Value == "name codeRepository");

        Logger.Log($"Printing {targetNodes.Count()} Repos");
        string text = "";
        foreach (var node in targetNodes)
        {
            text += $"{node.InnerText}\n";
        }
        List.text = text;
    }

    public void SetDialogSpeed(Slider slider)
    {
        _dialogSpeed = slider.value;
    }

    public async void StartDialog(Button button)
    {
        button.interactable = false;
        for (int i = 0; i < _dialogText.Length; ++i)
        {
            if (Application.isPlaying)
            {
                Dialog.text += _dialogText[i];
                await Task.Delay(TimeSpan.FromMilliseconds(_dialogSpeed));
            }
        }
        Dialog.text += "\nPress space to acknowledge...";
        while (!Input.GetKey(KeyCode.Space) && Application.isPlaying)
        {
            await Task.Delay(1);
        }
        button.interactable = true;
        Dialog.text = "";
    }

    private void Start()
    {
        _dialogText = Dialog.text;
        Dialog.text = "";
    }
}