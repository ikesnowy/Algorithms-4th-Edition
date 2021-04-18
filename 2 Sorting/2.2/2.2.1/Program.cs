//          a[]                                aux[]
// 0 1 2 3 4 5 6 7 8 9 10 11   i   j    0 1 2 3 4 5 6 7 8 9 10 11
// A E Q S U Y|E I N O S T            
// A E Q S U Y|E I N O S T              A E Q S U Y|E I N O S T
//                             0   6    A E Q S U Y|E I N O S T
// A                           1   6    A E Q S U Y|E I N O S T
// A E                         1   7      E Q S U Y|E I N O S T
// A E E                       2   7      E Q S U Y|  I N O S T
// A E E I                     2   8        Q S U Y|  I N O S T
// A E E I N                   2   9        Q S U Y|    N O S T
// A E E I N O                 2   10       Q S U Y|      O S T
// A E E I N O Q               3   10       Q S U Y|        S T
// A E E I N O Q S             3   11         S U Y|        S T
// A E E I N O Q S S           4   11         S U Y|          T
// A E E I N O Q S S T         4   12           U Y|          T
// A E E I N O Q S S T U       5   12           U Y|           
// A E E I N O Q S S T U Y     6   12             Y|           
// A E E I N O Q S S T U Y

return;