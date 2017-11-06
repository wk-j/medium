-- stack runghc --package http-client --package stm

{-# LANGUAGE NoOverloadedStrings #-}

import qualified Data.ByteString.Lazy.Char8 as L8
import Network.HTTP.Simple
import Control.Concurrent
import Control.Monad
import Control.Concurrent.STM

main :: IO()
main = do
    queue <- (atomically $ newTBQueue 1000) :: IO(TBQueue ())
    forkIO . forever $ do
        atomically $ writeTBQueue queue ()
        forkIO $ do
            response <- httpLbs "http://httpbin.org/get"
            L8.putStrLn $ getResponseBody response
            threadDelay 100000
            atomically $ readTBQueue queue
    getLine
    return ()




