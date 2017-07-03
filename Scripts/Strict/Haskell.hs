-- stack runghc --package strict

{-# LANGUAGE OverloadedStrings #-}
{-# LANGUAGE TypeFamilies #-}
{-# LANGUAGE EmptyDataDecls #-}
{-# LANGUAGE GeneralizedNewtypeDeriving #-}

module Data.Cased (
  Lower, Upper, Mixed,
  Cased(..),

  upperCased, lowerCased, mixedCased
) where

import Data.Text.Lazy (Text)
import Data.Hashable (Hashable)
import qualified Data.Text.Lazy as T

data Lower
data Upper
data Mixed
data Yes
data No

newtype Cased a = Cased { unCased :: Text }
                deriving (Show, Eq, Ord, Hashable)

type family IsLower a :: *
type family IsUpper a :: *

type instance IsUpper Lower = No
type instance IsUpper Upper = Yes
type instance IsUpper Mixed = No

type instance IsLower Lower = Yes
type instance IsLower Upper = No
type instance IsLower Mixed = No

mixedCased :: Text -> Cased Mixed
mixedCased = Cased

upperCased :: (IsUpper a ~ No) => Cased a -> Cased Upper
upperCased = Cased . T.toUpper . unCased

lowerCased :: (IsLower a ~ No) => Cased a -> Cased Lower
lowerCased = Cased . T.toLower . unCased

main = do
    let lowered = lowerCased . mixedCased $ "HelLo WorLd"
    print lowered