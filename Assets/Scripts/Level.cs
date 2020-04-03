using System;

[Serializable]
public class Level {

    public string message; 
    public int[] matrix; 

    public static string[] json = new string[3] {
        "{'message': 'Mensaje', 'matrix': [-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 1, 0, 0, 0, 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1]}",
        "{'message': 'Mensaje', 'matrix': [-1, -1, 2, -1, -1, -1, -1, 0, -1, -1, 1, 1, 0, 1, 2, -1, -1, 0, -1, -1, -1, -1, 2, -1, -1]}",
        "{'message': 'Mensaje', 'matrix': [-1, -1, 1, -1, -1, -1, -1, 0, -1, -1, 2, 0, 0, 0, 2, -1, -1, 0, -1, -1, -1, -1, 1, -1, -1]}"
    };

}

