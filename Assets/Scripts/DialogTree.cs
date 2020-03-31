using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogTree : MonoBehaviour
{
    public static List<string[]> DialogTrees { get; } = new List<string[]> 
    { 
        File.ReadAllLines("..\\Dialog\\test.txt") 
    };
}