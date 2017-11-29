#pragma warning disable RECS0165

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CounterLoop : MonoBehaviour
{
    public int Counter = 0;
    public Text CounterText;

    public async Task Count()
    {
        Logger.Log("Started counting.");
        while (Counter < 10)
        {
            Counter++;
            CounterText.text = Counter.ToString();
            await Task.Delay(1000);
        }
        Logger.Log("Stopped Counting");
    }

    private async void Start()
    {
        await Count();
    }
}