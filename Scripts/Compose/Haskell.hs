-- stack runghc --package strict

import Control.Category hiding ((.))
import Data.List

add1 = (+1)
add2 = (+2)

add3 = add1 <<< add2
add3' = add1 . add2

main = do
    print $ add3 5
    print $ add3' 5

    print $ sort . tail $ [5, 4, 3, 2, 1]
    print $ sort <<< tail $ [5, 4, 3, 2, 1]
    print $ tail >>> sort $ [5, 4, 3, 2, 1]
