-- stack runghc --package strict

main :: IO()
main = do
    let file = "Scripts/ReadWrite/foo.txt"
    contents <- readFile file
    writeFile file ('a' : contents)