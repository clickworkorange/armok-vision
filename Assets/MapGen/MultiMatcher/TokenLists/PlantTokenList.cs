﻿using UnityEngine;
using System.Collections.Generic;
using RemoteFortressReader;
using System;

static class PlantTokenList {
    static List<PlantRaw> _plantRawList;
    public static List<PlantRaw> PlantRawList
    {
        set
        {
            if(_plantRawList != value)
            {
                _plantRawList = value;
                PopulateWordLists();
            }
        }
    }

    private static void PopulateWordLists()
    {
        throw new NotImplementedException();
    }
}