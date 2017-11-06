-- stack runghc --package strict

import Data.Foldable
import Data.Function

main = do
    [Just "Hello", Just "World"] & asum    & print  -- Just "Hello"
    ["Hello", "World"] & asum & print               -- "HelloWorld" 



    [Just "Hello", Just "World"] & mconcat & print  -- Just "HelloWorld"