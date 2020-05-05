﻿using System;

[Serializable]
public class Level {

    public int[] matrix; 

    public static string[] json = new string[8] {
        "{'matrix': [-1,-1,-1,1,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,2,-1,-1,-1]}",
        "{'matrix': [-1,-1,1,-1,2,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,2,-1,1,-1,-1]}",
        "{'matrix': [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,3,0,0,0,0,0,4,-1,-1,-1,-1,-1,-1,-1,6,0,0,0,0,0,5,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1]}",
        "{'matrix': [-1,-1,-1,4,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,0,3,-1,-1,-1,-1,2,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,1,-1,-1,-1]}",
        "{'matrix': [-1,-1,-1,1,-1,-1,-1,-1,-1,-1,3,0,0,6,-1,-1,-1,5,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,4,0,0,0,-1,-1,-1,-1,-1,-1,2,-1,-1,-1]}",
        "{'matrix': [1,0,0,0,0,0,1,0,-1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,0,2,0,0,2,0,0,0]}",
        "{'matrix': [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,4,6,1,3,5,0,2,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,-1,-1]}",
        "{'matrix': [-1,-1,-1,2,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,3,-1,-1,-1,2,0,1,0,1,4,-1,-1,-1,-1,3,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,4,-1,-1,-1]}"
    };

}