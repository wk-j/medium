
import Control.Monad

main = 
 print =<< liftM2 (+) readLn readLn