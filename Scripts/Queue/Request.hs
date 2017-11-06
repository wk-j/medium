-- stack runghc --package http-conduit --package stm --package bytestring
{-# LANGUAGE OverloadedStrings #-}

module Main where

import qualified Data.ByteString.Lazy.Char8 as L8
import Control.Concurrent
import Control.Monad
import Control.Concurrent.STM
import Network.HTTP.Simple

main :: IO ()
main = do
    queue <- (atomically $ newTBQueue 10) :: IO (TBQueue ())
    forkIO . forever $ do
        atomically $ writeTBQueue queue ()
        forkIO $ do
            response <- httpLBS "http://httpbin.org/get"
            L8.putStrLn $ getResponseBody response
            threadDelay 100000
            atomically $ readTBQueue queue
    getLine
    return ()