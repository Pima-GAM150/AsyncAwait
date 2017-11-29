using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Logger
{
    public static void Log(object msg) => Debug.Log($"[{GetTimeStamp()}] {msg}");

    public static void Error(object msg) => Debug.LogError($"[{GetTimeStamp()}] {msg}");

    private static string GetTimeStamp() => DateTime.Now.ToString("T");
}