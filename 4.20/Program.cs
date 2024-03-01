Console.WriteLine("Введите часы:");
int hours = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Введите минуты:");
int minutes = Convert.ToInt32(Console.ReadLine());

int total;

if ((hours > 0) && (minutes > 0) && (minutes < 59))
{
    total = (hours * 60) + minutes;
    Console.WriteLine($"Время в минутах: {total} ");
}
else
{
    Console.WriteLine("Значение введено некорректно222");
}