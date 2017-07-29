#load "../App/Logo/Logo.fsx"


let settings = Logo.DrawSettings.Default()

//let font = "Herculanum"
let font = "AppleMyungjo"

//let newSettings = { settings with Background = "Red"; FontFamily = "American Typewriter"}
let newSettings = { settings with Background = "White"; Foreground = "Black" ; FontFamily = font }

Logo.drawText("♥", "_resource/W.png", newSettings)