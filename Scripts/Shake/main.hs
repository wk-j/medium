-- stack runghc --package shake

import Development.Shake

main :: IO()
main = shakeArgs shakeOptions $ do
    want ["main.txt"]
    "main.txt" %> \_ -> do
        need ["Shake/main.hs"]
        () <- cmd "touch Shake/main.txt"
        return ()

