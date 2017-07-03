using System;

class Passenger {
    public DateTime? BirthDate { set;get; }
}

bool vv(Passenger[] passengers)
{
    var result = true;
    DateTime? oldestDate = DateTime.MaxValue;
    foreach (var passenger in passengers)
    {
        if (passenger.BirthDate < oldestDate)
        {
            oldestDate = passenger.BirthDate;
        }
    }
    if (oldestDate > DateTime.Now.AddYears(-18))
    {
        result = false;
    }
    return result;
}

bool vvv(Passenger[] passengers)
{
    var oldestDate = passengers.Min(passenger =>
    {
        return passenger.BirthDate ?? DateTime.MaxValue;
    });
    return oldestDate > DateTime.Now.AddYears(-18);
}


 bool v0(Passenger[] passengers)
{
    var oldestDate = passengers.Min(passenger =>
    {
        return passenger.BirthDate ?? DateTime.MaxValue;
    });
    return oldestDate > DateTime.Now.AddYears(-18);
}

bool v1(Passenger[] passengers) {
    var oldestDate = passengers.Min(passenger => {
        return passenger.BirthDate ?? DateTime.MaxValue;
    });
    return oldestDate > DateTime.Now.AddYears(-18);

}

Func<int, Func<Passenger, bool>> NotOlderThen = (age) =>  {
    //Console.WriteLine("Hello, world");
    return (passenger) => passenger.BirthDate > DateTime.Now.AddYears(-age);
};

bool v2 (IEnumerable<Passenger> passengers) => 
    passengers.All(NotOlderThen(18));

bool v3(IEnumerable<Passenger> passengers) {
    var notOlderThen18 = NotOlderThen(18);
    return passengers.All(notOlderThen18);
}

var list = new List<Passenger> {
    new Passenger { BirthDate = new DateTime(2020, 10, 10) },
    new Passenger { BirthDate = new DateTime(2010, 10, 10) },
    new Passenger { BirthDate = new DateTime(2000, 10, 10) },
    new Passenger { BirthDate = new DateTime(1986, 10, 10) },
}.ToArray();

Console.WriteLine(vv(list));
Console.WriteLine(vvv(list));
Console.WriteLine(v0(list));
Console.WriteLine(v1(list));
Console.WriteLine(v2(list));
Console.WriteLine(v3(list));

