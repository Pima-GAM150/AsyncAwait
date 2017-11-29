#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SimpleAwaitedTask : MonoBehaviour
{
    private int _timesClicked;
    private int _localTimesClicked;

    public async void OnClickNoLocal()
    {
        _timesClicked++;
        Logger.Log($"This is printed by OnClick press number: {_timesClicked}");
        await Task.Delay(2000);
        Logger.Log($"This is printed 2 seconds later by OnClick press number: {_timesClicked}");
    }

    public async void OnClickLocal()
    {
        _localTimesClicked++;
        // Save what click we are on for this instance of the method.
        var thisClick = _localTimesClicked;
        Logger.Log($"This is printed by OnClick press number: {_localTimesClicked}");
        await Task.Delay(2000);
        Logger.Log($"This is printed 2 seconds later by OnClick press number: {thisClick}");
    }

    private async void Start()
    {
        Logger.Log("This is printed on Start!");
        await Task.Delay(2000);
        Logger.Log("This is printed 2 seconds after start!");
    }
}