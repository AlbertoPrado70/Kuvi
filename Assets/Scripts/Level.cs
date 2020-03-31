using System;

[Serializable]
public class Level {

    public int[] matrix; 

    public static string[] json = new string[1] {
        "{'matrix': [0, 0, 0, 0, 0, 1, -1, -1, -1, 0, 0, -1, -1, -1, 0, 0, -1, -1, -1, 0, 0, 0, 0, 0, 0]}"
    };

}
