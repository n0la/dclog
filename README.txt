
 README
 
 This is a DPS meter and combat log application for Dungeons & Dragons: Online.
 It reads the combat log, parses it and hopefully creates pretty and useful 
 graphs from it.

 
 Before we begin...

 This software violates Dungeons & Dragons: Online EULA to which YOU agreed when
 you ran the game the very first time. This is your responsibility and you alone
 are to blame for the consequences Turbine may set. By running this application
 you agree that the consequences are yours to face. If you do not wish to break
 this EULA you probably shouldn't run or distribute this application. 

 
 How to get it running:

 1. Disable UAC.
 2. Disable any AntiVir software you might have that could interfere.
 3. Download Visual C# Express 2010.
 4. Open the solution and compile the entire solution.
 
 Then either:

 5. Copy the contents of each {dclog|ddo|ddohook}\bin\Release\ into one single 
    directory.
 6. Copy the contents of easyhook\ into this new folder.
 7. Run dclog.exe

 Or:

 5. Copy the contents of {ddo|ddohook}\bin\Release into the dclog\bin\Debug 
    directory.
 6. Copy the contents of easyhook into dclog\bin\Debug directory.
 7. Run "Start" or "Debug" from Visual Studio.

 8. Run the game.
 9. Select "File" -> "Attach" in the Main Window.
 10. Have fun!
 
 