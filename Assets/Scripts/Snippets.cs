// This will prevent 'green sqigglies' under unity messages.
// Ideally async methods should return Tasks but unity messages only work returning void.
#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// This is a collection of snippets to use in any project.
/// I've tried to make them as 'plug and play' as possible.
/// </summary>
public class Snippets : MonoBehaviour
{
    /// <summary>
    /// Any default unity message (OnDestroy, Start, Awake, Etc..) can be marked as async void.
    /// Asnyc must come before the return type and after the scope.
    /// </summary>
    public async void Start()
    {
    }

    /// <summary>
    /// This is an example of a simple loop boilerplate.
    /// </summary>
    public async Task Loop()
    {
        // Exit while loop if not playing
        while (true && Application.isPlaying)
        {
            // Do Something.
            await Task.Delay(1000);
        }

        for (; ; )
        {
            // Exit loop if not playing.
            if (!Application.isPlaying)
                break;
        }
    }

    /// <summary>
    /// This can be used as a replacement for Task.Delay to use seconds instead.
    /// Example: await WaitForSeconds(5f);
    /// </summary>
    public async Task WaitForSeconds(float seconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(seconds));
    }

    /// <summary>
    /// Waits for the user to press a certain key.
    /// Example:
    /// await WaitForKeyPress(KeyCode.Space);
    /// </summary>
    public async Task WaitForKeyPress(KeyCode key)
    {
        while (!Input.GetKey(key) && Application.isPlaying)
        {
            await Task.Delay(1);
        }
    }

    /// <summary>
    /// Waits for the user to press a certain key passed as a string.
    /// Example:
    /// await WaitForKeyPress("Horizontal");
    /// </summary>
    public async Task WaitForKeyPress(string key)
    {
        while (!Input.GetKey(key) && Application.isPlaying)
        {
            await Task.Delay(1);
        }
    }
}