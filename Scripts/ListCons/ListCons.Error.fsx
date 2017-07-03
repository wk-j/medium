let list = 100 :: [200;300]  // [100;200;300]

let flip f x y = f y x
let rev xs = List.fold (flip (::)) [] xs
// error FS0010: Unexpected symbol '::' in expression

let newList = rev list