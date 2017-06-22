-- stack runghc --package strict 

import Prelude hiding (readFile)
import System.IO.Strict (readFile)
import Data.List (sortBy)
import Data.Ord (comparing)

data R = R { p :: Int, dff :: Int }
    deriving Show

genList :: [a] -> [(a,a,a)]
genList xs = do
    x <- xs          
    y <- xs          
    z <- xs
    return (x,y,z)     

diff :: Int -> (Int, Int, Int) -> R
diff target (x,y,z) = do
    let s = x * y * z
    let d = abs( target - s)
    R { p = s, dff = d }

main :: IO()
main = do
    -- contents <- readFile "CodeBattle101/LargeCase.txt"
    contents <- readFile "CodeBattle101/SmallCase.txt"
    let target = 29592974112914
    let list = lines contents
    let numbers =  map read list :: [Int]
    let tuple = genList numbers
    let removed = filter (\(x,y,z) -> x /= y && x /= z && y /= z) tuple 
    let diffed = map (diff target) removed
    let ordered = sortBy (comparing dff) diffed
    print $ take 1 ordered
    