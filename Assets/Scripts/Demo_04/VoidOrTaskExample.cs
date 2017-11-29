#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This will have unintended behavior without adding 'Application.isPlaying' to while loops!
/// </summary>
public class VoidOrTaskExample : MonoBehaviour
{
    public RectTransform VoidTarget;
    public RectTransform TaskTarget;

    public float TranslateTime = 2f;

    /// <summary>
    /// Moves a button with async void!
    /// </summary>
    public void OnClickVoid(Button button)
    {
        Logger.Log("Void Move Started!");
        VoidMoveX(button);
        VoidMoveY(button);
        Logger.Log("Void Move Complete!");
    }

    /// <summary>
    /// Translates the buttons X position using async/await.
    /// </summary>
    public async void VoidMoveX(Button button)
    {
        var rect = button.transform as RectTransform;
        var x = rect.anchoredPosition.x;
        var tarX = VoidTarget.anchoredPosition.x;

        var time = 0f;

        while (!Mathf.Approximately(rect.anchoredPosition.x, tarX))
        {
            var newX = Mathf.Lerp(x, tarX, time);
            time += Time.deltaTime * TranslateTime;
            time = Mathf.Clamp(time, 0, 1);
            rect.anchoredPosition = new Vector2(newX, rect.anchoredPosition.y);
            await Task.Delay(1);
        }
    }

    /// <summary>
    /// Translates the buttons Y position using async/await.
    /// </summary>
    public async void VoidMoveY(Button button)
    {
        var rect = button.transform as RectTransform;
        var y = rect.anchoredPosition.y;
        var tarY = VoidTarget.anchoredPosition.y;

        var time = 0f;

        while (!Mathf.Approximately(rect.anchoredPosition.y, tarY))
        {
            var newY = Mathf.Lerp(y, tarY, time);
            time += Time.deltaTime * TranslateTime;
            time = Mathf.Clamp(time, 0, 1);
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, newY);
            await Task.Delay(1);
        }
    }

    /// <summary>
    /// Moves a button using async Tasks
    /// </summary>
    public async void OnClickTask(Button button)
    {
        Logger.Log("Task Move Started!");
        await TaskMoveX(button);
        await TaskMoveY(button);
        Logger.Log("Task Move Complete!");
    }

    /// <summary>
    /// Awaitable Task. Moves a buttons X value.
    /// </summary>
    public async Task TaskMoveX(Button button)
    {
        var rect = button.transform as RectTransform;
        var x = rect.anchoredPosition.x;
        var tarX = VoidTarget.anchoredPosition.x;

        var time = 0f;

        while (!Mathf.Approximately(rect.anchoredPosition.x, tarX))
        {
            var newX = Mathf.Lerp(x, tarX, time);
            time += Time.deltaTime * TranslateTime;
            time = Mathf.Clamp(time, 0, 1);
            rect.anchoredPosition = new Vector2(newX, rect.anchoredPosition.y);
            await Task.Delay(1);
        }
    }

    /// <summary>
    /// Awaitable Task. Moves a buttons Y value.
    /// </summary>
    public async Task TaskMoveY(Button button)
    {
        var rect = button.transform as RectTransform;
        var y = rect.anchoredPosition.y;
        var tarY = TaskTarget.anchoredPosition.y;

        var time = 0f;

        while (!Mathf.Approximately(rect.anchoredPosition.y, tarY))
        {
            var newY = Mathf.Lerp(y, tarY, time);
            time += Time.deltaTime * TranslateTime;
            time = Mathf.Clamp(time, 0, 1);
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, newY);
            await Task.Delay(1);
        }
    }
}