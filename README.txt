
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
 3. Download Visual C# Express 2010 and Visual C++ Express 2010.
 4. Open the solution and compile the entire solution.
 5. Open the solution dclog.sln and the ddohook/ddohook.sln.
 6. Compile everything.
 7. Copy every binary you can find into one single folder, except the files 
    *plugin.dll, they go in a subfolder called plugins/ beneath dclog.exe.
 8. Copy the EasyHook binaries into the same folder.
    
  Your directory hierarchy should look something like this:
  
   .
     \ dclog.exe
     \ ddo.dll
     \ EasyHook.dll
     \ EasyHook32.dll
     \ EasyHook32Svc.exe
     \ EasyHook64.dll
     \ EasyHook64Svc.exe
     \ libdclog.dll
     \ nativeddohook.dll
     \ plugins
        \ dpsplugin.dll
        \ tankplugin.dll
        
 The plugins are optional, but the application makes more sense with them.
 
 **NOTE**:  A debug build of nativeddohook.dll writes a log to D:\. If you don't
            have a D:\ you are in trouble. Take a release build of 
            nativeddohook.dll instead.
 