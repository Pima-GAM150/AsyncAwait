#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ErrorThrowingTasks : MonoBehaviour
{
    public async void OnClickVoidError()
    {
        Logger.Log("Throwing an error from a non-Task");
        await Task.Delay(100);
        await ThrowError();
    }

    public void OnClickTaskError()
    {
        TaskError();
    }

    public async Task ThrowError()
    {
        throw new System.Exception();
    }

    public async Task TaskError()
    {
        Logger.Log("Throwing an error from a Task!");
        await Task.Delay(100);
        await ThrowError();
        Logger.Log("This message should never print because an exception was thrown!");
    }
}