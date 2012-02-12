
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

 
 FAQ
 
 Q: Can this application crash DDO?
 A: Yes it can, and are no warranties for any damages this application causes.
 
 Q: Can it be that this applicaton slows down DDO?
 A: Sadly yes. While there are things that can be done to minimise this, it is
    as of yet no development priority.
    
 Q: Are German and French of the game versions supported?
 A: At the moment: No. Although the mother tongue of the developer is German,
    translating it to work with the German language is no development priority.
    
 Q: Does this application include spyware, a virus, trojans, toolbars, search
    engine redirects or even ads?
 A: No. The application is open source, and you any programmer that looks at
    the source code (the stuff this application is made of) can verify that its
    free of any such nonsense.
 
 Q: Does this application violate the EULA?
 A: Yes see WORKINGS-EULA.txt for details.
 
 Q: How does this application work?
 A: See WORKINGS-EULA.txt for details.
 
 Q: Did Turbine approve of this application?
 A: No. But I hope they will :->
 
 Q: Does this application change anything in the game?
 A: No. This application only retrieves information from the client and does not
    change anything from the game. No files are modified, no heap memory is
    tempered with and it should stay that way.
 
 Q: Are all combat logs and types recognised?
 A: While this application aims to fully support every aspect of the game,
    it can very well be that a certain type is not yet recognised. If you think
    the application does not recognise something it should file a bug report!
    
 Q: How do I file a bug report?
 A: File one here: https://github.com/n0la/dclog/issues
 
 Q: Who is the developer of this application?
 A: An Austrian called Florian Stinglmayr, aka Nola.
 
 Q: How can I reach him?
 A: Per Email please: fstinglmayr@gmail.com
 
 