class Account { 
    public int Amount { set;get;}
}
class Customer { 
    public Account Account { set;get;}
}

var cust = new Customer();
let acount = cust?.Accout?.Amount ?? 0;
Console.WriteLine(account);
