-- stack runghc --package strict

module X where

import Control.Applicative
import Control.Arrow

liftM2 :: Monad m => (t1 -> t -> b) -> m t1 -> m t -> m b
liftM2 f m1 m2  = do 
    x1 <- m1
    x2 <- m2
    return (f x1 x2) 

main :: IO ()
main = do
    print $ liftM2 (==) id reverse [1,2,3,2,1]  -- True 
    print $ liftM2 (+) (Just 1) (Just 2)        -- Just 3
    print $ liftM2 (+) (Just 1) Nothing         -- Nothing
    print $ liftM2 (+) [1]  [1,2]               -- [2,3]

    print $ (+) <$> [0,1] <*> [0,2]

    -- print $ liftM2 (***) (Just 100) (Just 200)
