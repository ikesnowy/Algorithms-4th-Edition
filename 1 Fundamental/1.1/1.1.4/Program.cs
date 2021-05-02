// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable RedundantAssignment
#pragma warning disable 219
var a = 1;
var b = 2;
var c = 0;

// if (a > b) then c = 0; 
// if 后不能跟 then

// if a > b { c = 0; } 
// if后必须跟括号

if (a > b)
    c = 0;
// 正确

// if (a > b) c = 0 else b = 0; 
// c = 0后缺少分号