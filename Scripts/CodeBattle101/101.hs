module CodeBattle101 (solve) where

import Data.List (sort, delete, tails)
import qualified Data.Vector as V (fromList, length, Vector, (!), toList)

newtype IPair = IPair (Int, Int)
newtype RPiar = RPair (Int, Int)

solve :: Int -> [Int] -> Int
solve n ns = r
    where
        zs          = V.fromList $ sort ns
        pr          = RPair (maxBound :: Int, 0)
        ips         = [IPair (x,y) | [x,y] <- coms 2 ns]
        RPiar(_,r)  = fold (search n zs 0) (V.length zs)) rp ips

search :: Int -> V.Vector Int -> Int -> Int -> RPair -> IPair -> RPair
search n zs l h = search' (n, zs, l, h, i z)
    where
            i = (l + h) `div` 2
            z = zs V.! -i

search' (n, zs, _,_,_,z) b