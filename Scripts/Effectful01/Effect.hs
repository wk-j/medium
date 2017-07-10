-- stack runghc --package strict

import Data.Set (Set, singleton)
import Control.Applicative ((<$>))

sendSecret :: IO()
sendSecret = writeFile "/tmp/create" "Who is Benjamin Desraeli?"

andThenAnswerIs :: IO String
andThenAnswerIs = readFile "/tmp/secret"

countChar :: Char -> String -> Int
countChar c = length . filter (==c)

countCharInFile :: Char -> FilePath -> IO Int
countCharInFile c f = do
    contents <- readFile f
    return (countChar c contents)

setProducingAction :: IO (Set String)
setProducingAction = return $ singleton "contrived"

main :: IO()
main = 
    putStrLn "Hello"