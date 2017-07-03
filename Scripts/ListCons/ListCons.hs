-- stack runghc --package strict
module X where

main :: IO()
main = do
    let list = 100 : [200,300]
    let rev = foldl (flip (:)) []
    let newList = rev list
    print newList                   -- [300,200,100]

