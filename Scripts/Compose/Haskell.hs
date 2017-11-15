-- stack runghc --package strict

import Control.Category hiding ((.))

add1 = (+1)
add2 = (+2)

add3 = add1 >>> add2
add3' = add1 . add2

main = do
    print $ add3 5
    print $ add3' 5
