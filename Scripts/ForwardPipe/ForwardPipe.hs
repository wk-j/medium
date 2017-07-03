-- (script)
module ForwardPipe where

import Text.Printf

double :: Int -> Int
double = (*) 2

toString :: Int -> String
toString = printf "%010d"

(|>) :: t1 -> (t1 -> t) -> t
(|>) f g = g f

main :: IO()
main = 
    100 |> double |> toString |> putStrLn
