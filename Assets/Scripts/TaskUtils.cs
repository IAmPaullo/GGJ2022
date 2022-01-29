using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public static class TaskUtils
{
    public async static Task WaitUntil(Func<bool> predicate)
    {
        while (!predicate()) { }
    }
}