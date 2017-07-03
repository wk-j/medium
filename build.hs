-- stack runghc --package shake

import Development.Shake

main :: IO()
main = shakeArgs shakeOptions $ do

    phony "test" $
        cmd "dotnet test Source/Medium.Facts/Medium.Facts.csproj"

    phony "restore" $ do
        () <- cmd "dotnet restore Source/Medium/Medium.csproj"
        () <- cmd "dotnet restore Source/Medium.Facts/Medium.Facts.csproj"
        return ()
