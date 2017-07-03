-- stack runghc --package shake

import Development.Shake


main :: IO()
main = shakeArgs shakeOptions $ 
    -- want ["Shake/main.txt"]
    return ()
