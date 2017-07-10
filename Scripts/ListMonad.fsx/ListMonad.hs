-- stack runghc

dup :: [a] -> [a]
dup xs = do
    x <- xs 
    [x,x]

main :: IO()
main = do
    print $ dup [1,2,3]         -- [1,1,2,2,3,3]
    print $ dup ["A","B","C"]   -- ["A","A","B","B","C","C"]