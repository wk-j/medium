
class Passenger {
    public DateTime? BirthDate { set;get; }
}

bool v1(Passenger[] passengers) {
    var result = true;
    DateTime? oldestDate = DateTime.MaxValue;
    foreach (var passenger in passengers) {
        if (passenger.BirthDate < oldestDate) {
            oldestDate = passenger.BirthDate;
        }
    }
    if (oldestDate > DateTime.Now.AddYears(-18)) {
        result = false;
    }
    return result;
}

bool v2(Passenger[] passengers) {
    var oldestDate = passengers.Min(passenger => {
        return passenger.BirthDate ?? DateTime.MaxValue;
    });
    return oldestDate > DateTime.Now.AddYears(-18);
}

var list = new List<Passenger> {
    new Passenger { BirthDate = new DateTime(2020, 10, 10) },
    new Passenger { BirthDate = new DateTime(2010, 10, 10) },
    new Passenger { BirthDate = new DateTime(2000, 10, 10) },
}.ToArray();

Console.WriteLine(v1(list));        // False
Console.WriteLine(v2(list));        // True

