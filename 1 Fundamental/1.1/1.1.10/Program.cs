// ReSharper disable EmptyForStatement
int[] a;
for (var i = 0; i < 10; i++)
{
    // a[i] = i * i; // 不允许使用未赋值的局部变量
}

a = new int[10];
for (var i = 0; i < 10; i++)
{
    a[i] = i * i; // 初始化后可用
}