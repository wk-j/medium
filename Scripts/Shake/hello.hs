-- stack runghc --package shake

import Development.Shake

main :: IO()
main = do
        () <- cmd "echo Hello"
        () <- cmd "echo World"
        return ()