-- stack runghc 

module Main where

import qualified Control.Monad.IO.Class as Class
import qualified Control.Exception as Exception
import qualified System.Console.Haskeline as HaskellLine
import qualified Data.Time as Time
import qualified Data.Maybe as Maybe
import qualified System.Exit as Exit

main :: IO ()
main = HaskellLine.runInputT HaskellLine.defaultSettings app

app :: HaskellLine.InputT IO ()
app = do
  name <- getName
  HaskellLine.outputStrLn $ "Hello, " ++ name ++ "!"
  birthdayE <- getBirthday
  either (\_ -> do
            HaskellLine.outputStrLn "Invalid birthday"
            Class.liftIO $ Exit.exitWith (Exit.ExitFailure 2)
         )
         (\birthday -> do
            age <- calcAge birthday
            HaskellLine.outputStrLn $ "You are " ++ age ++ " years old."
         )
         birthdayE

getName :: HaskellLine.InputT IO String
getName = do
  minput <- HaskellLine.getInputLine "Hello, what is your name?\n"
  return $ Maybe.fromMaybe "" minput

getBirthday :: HaskellLine.InputT IO (Either HaskellLine.SomeException Time.UTCTime)
getBirthday = do
  minput <- HaskellLine.getInputLine "Birthday (format: dd/mm/yyyy, e.g.: 21/06/1985)\n"
  Class.liftIO $ Exception.try $ Time.parseTimeM False Time.defaultTimeLocale "%d/%m/%Y" $ Maybe.fromJust minput

calcAge :: Time.UTCTime -> HaskellLine.InputT IO String
calcAge birthday = do
  (ny, nm, nd) <- Class.liftIO $ fmap (Time.toGregorian . Time.utctDay) Time.getCurrentTime
  let (by, bm, bd) = Time.toGregorian (Time.utctDay birthday)
  let age = if nm >= bm && nd >= bd then ny - by else ny - by - 1
  return $ show age
  