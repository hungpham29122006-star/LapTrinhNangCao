using System;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");
int a;
int b;
int c;
Console.Write("Nhập a: ");
a = Convert.ToInt32(Console.ReadLine());

while (true)
{
    Console.Write("Nhập b: ");

    try
    {
        b = int.Parse(Console.ReadLine());
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Nhập sai! Vui lòng nhập lại: ");
    }
}

bool k;
while (true)
{
    Console.Write("Nhập c: ");
    k = int.TryParse(Console.ReadLine(), out c);
    if (k)
        break;
    else
        Console.WriteLine("Nhập sai! Vui lòng nhập lại: ");
}
Console.WriteLine($"{a} + {b} + {c} = {a + b + c}");
