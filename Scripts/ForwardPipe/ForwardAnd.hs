-- stack runghc

import Data.Function

(|>) a b = b a

main :: IO()
main = do
    20 & (+10) & (+5) & print        
    20 |> (+ 10) |> (+ 5) |> print     

    [10,20,30] & filter (> 10) & print
    [10,30,30] |> filter (> 10) |> print