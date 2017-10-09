-- stack runghc

main :: IO ()
main = print $ quicksort [1, 123, 42, 90, 24, 12, 3 :: Int]

quicksort :: Ord t => [t] -> [t]
quicksort [] = []
quicksort (x:xs) = quicksort left ++ [x] ++ quicksort right
    where left  = [ y | y <- xs, y < x ]
          right = [ y | y <- xs, y >= x ]