using System;

[Serializable]
public class Level {

    public string message; 
    public int[] matrix; 

    public static string[] json = new string[2] {
        "{'message': 'Nivel 1', 'matrix': [-1,-1,-1,1,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,2,-1,-1,-1]}",
        "{'message': 'Nivel 2', 'matrix': [-1,-1,1,-1,2,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,0,-1,0,-1,-1,-1,-1,2,-1,1,-1,-1]}",
    };

}

