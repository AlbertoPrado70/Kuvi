using UnityEngine;

public class Solver {
    
    public string[] solution = new string[50]{
        "b03;",
        "t64;b02;",
        "l46;r20;",
        "t41;r21;b23;r43;t45;", 
        "t60;r00;b06;l66;t62;r22;b24;",
        "r33;r30;",
        "l35;t63;t33;",
        "b23;b13;l53;t63;r13;b03;",
        "r34;r33;b35;l36;t55;r35;r33;b35;r32;b35;l36;t45;r35;t55;l35;",
        "t53;l23;t63;r23;t13;",
        "r04;r03;b05;l02;l06;b01;r61;l65;r00;l66;t65;l05;r60;t61;r01;b05;l06;t65;r05;",
        "l21;t20;r53;t54;r25;b26;t50;r20;b22;r52;t54;r24;b26;",
        "r32;r31;r30;b34;l35;l36;t31;r30;",
        "b06;l26;l66;t64;r04;b06;r00;b02;t20;r00;t60;r40;b46;l66;",
        "b00;b06;l66;t60;r00;b06;l66;l61;t60;r00;b06;l66;l62;",
        "b43;b00;r60;b06;l66;t63;l64;l43;t42;t63;r43;t44;l24;",
        "r64;l62;t45;l25;t41;r21;b06;l26;b25;l45;b44;r64;b00;r20;b21;r41;b42;l62;",
        "t55;r51;b25;b15;r11;l55;t51;b45;l55;r11;t51;l14;l15;b11;r51;l12;b11;l55;t52;",
        "r34;r33;t35;l36;b15;r35;r33;t35;l32;l36;b31;r30;t51;l31;l36;b31;",
        "t54;t52;",
        "t34;l14;b12;t54;l14;r53;t54;l14;r52;t54;",
        "r51;b11;l54;l55;l15;t51;l52;t51;r11;t21;l15;",
        "r64;r60;r20;r24;b06;b46;b42;b02;",
        "t31;l13;t35;l15;t13;b11;r12;b15;l55;t51;r11;b15;l55;b53;",
        "t63;l66;t63;b00;r30;b36;l66;l03;b00;r30;t13;l03;b00;t63;",
        "r11;b12;l52;t51;b15;l55;r41;t51;r41;b13;l53;t51;r41;b45;l55;t51;r41;b42;b44;",
        "l36;t32;r31;r30;b12;l35;l36;b34;r33;t54;l34;l36;b34;t32;",
        "r32;l24;t34;t44;r34;r43;r42;b43;b32;b22;l32;b24;r34;l44;b43;l23;t42;l32;b13;",
        "l33;b23;l33;t65;l35;t33;r13;r32;r31;t61;r31;t33;l13;",
        "t31;l32;t31;l11;b35;r34;b35;r55;l15;r51;",
        "r00;b06;l66;t60;r00;b06;l66;l61;t60;r00;b06;l66;t63;r33;r32;r62;t66;b33;r63;t66;",
        "l56;b14;r10;b12;r54;t56;l16;l52;t50;r10;b14;l34;b42;b32;b12;r32;t34;r14;t42;",
        "l05;t63;l06;b03;r02;b03;r01;b03;r00;t43;t53;t63;",
        "r04;b06;l26;b02;t20;r00;b02;t60;r40;l66;t64;b46;l66;t64;l62;t60;r40;b52;l62;t60;r04;b06;l26;t20;t14;r04;",
        "b06;l66;t63;r60;l03;b00;t63;r60;t63;l03;b00;r60;t63;t13;l03;b00;r60;t63;r64;t23;l03;",
        "l55;b15;l55;t53;b11;r41;t51;r11;b15;b43;l55;l52;t51;r11;t53;b15;t54;r14;b15;r43;t45;l55;t51;l15;b11;r51;t55;l15;",
        "l55;t51;r11;b15;l55;t51;l21;l31;l32;b31;t21;r11;r51;t55;l15;b11;r51;t55;r35;t25;r34;b35;l55;",
        "l55;b15;l55;t52;r51;t52;b11;r51;t52;r12;b15;l55;t22;r12;t54;b15;l55;t54;r14;b15;l55;t54;r24;b25;l32;r34;l53;t51;t55;r41;b45;l55;t51;r41;l35;r31;",
        "l66;b06;r00;l66;b06;t60;l66;r00;b06;l66;t63;r62;t63;l61;t60;r00;l64;t60;r00;b06;l66;t60;r00;r05;b06;l66;t60;r00;b03;",
        "l66;b06;r60;b00;r60;t64;t66;l06;r65;t66;b00;l06;r60;t66;l06;b00;r60;t66;l06;b02;",
        "b04;t62;l64;r02;b04;t62;r02;l64;b04;t62;b54;b44;l64;l43;t62;t12;t22;r23;r02;b04;",
        "r32;t62;r32;t34;l66;t62;r32;t34;l14;b10;b36;l66;t62;r32;t34;l14;b10;b04;",
        "l55;b15;l55;r11;b15;l55;t53;r52;t53;r51;t53;l13;b11;r51;t23;t33;l13;t53;b11;r51;t53;t23;t33;l13;b11;t43;r51;t53;",
        "b00;r60;l06;b00;r60;t66;l06;b00;r65;t66;l06;r60;t63;b00;r60;t63;l03;b00;r60;t63;t13;l03;b00;r60;t63;",
        "l66;b06;l66;r00;b06;l66;t63;t60;r00;b06;l66;l61;t60;r00;b06;l66;l43;t63;r62;t42;l43;t42;t63;r22;b24;t32;r22;l43;l44;t42;r22;",
        "t53;t23;t51;r11;r43;b15;l45;b13;l23;b21;r41;b12;b45;l55;t53;t52;",
        "b10;l16;b10;t56;l16;b10;r50;t56;l16;r30;b20;r30;b10;r30;t36;l16;b10;r35;r34;r30;t36;l16;b10;r30;r35;t36;l16;b10;r30;",
        "t62;l66;b12;b02;l06;b02;l32;t30;t36;l06;t42;t52;t62;l32;r02;b06;l66;r30;l32;b22;r30;b12;r22;l32;t52;r30;b02;r22;t62;r42;l32;b30;",
        "l32;l34;b23;r33;r31;r30;t33;l34;b43;",
        "l44;t43;t40;t46;l26;b23;r20;l42;t40;r24;r20;l43;t40;r20;l26;b23;r22;r24;"
    };

    public string[] currentSolution; 
    public int currentMove; 

    public Solver() { 
        currentMove = 0; 
    }

    public void parseSolution(int level) {
        level = (level > solution.Length - 1) ? 0 : level; 
        currentSolution = solution[level].Split(';');
        currentMove = 0; 
    }

    public Movement makeMove() {

        Movement movement = new Movement();

        movement.move = MoveCube.Move.NONE; 

        movement.move = (currentSolution[currentMove][0] == 't') ? MoveCube.Move.TOP : movement.move;
        movement.move = (currentSolution[currentMove][0] == 'r') ? MoveCube.Move.RIGHT : movement.move;
        movement.move = (currentSolution[currentMove][0] == 'b') ? MoveCube.Move.BOTTOM : movement.move;
        movement.move = (currentSolution[currentMove][0] == 'l') ? MoveCube.Move.LEFT : movement.move; 
        
        int row = (int) char.GetNumericValue(currentSolution[currentMove][1]);
        int column = (int) char.GetNumericValue(currentSolution[currentMove][2]);

        movement.row = row; 
        movement.column = column; 
        currentMove++; 

        return(movement); 

    }

}