// See https://aka.ms/new-console-template for more information




Console.WriteLine(factorial(5));

int factorial(int v)
{
    return v == 0 ? 1 : v * factorial(v - 1);
}