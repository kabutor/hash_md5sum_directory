This repo consists of two small programs:

list_files.ps1 - > A Powershell script that will create a csv file c:\temp\ with the md5sum of a given folder, by default Program Files(x86) Office12 folder, as this is the main purpose of this, to check the file integrity of Office 2007.

hash.exe -> This file is created compiling hash.cs, by default will load the md5_checksum.cvs created by the above PWSH script, has to be in the same folder as this executable (don't forget to remove the two header lines created by the script), and will check
those files against the md5sum in the cvs in order to ensure that the file integrity is right.
You can pass any argument (-whatever) when running hash.exe and that will also list the files that are in the folder that are not listed on the CSV file.

You can suit this program to any folder just replacing on the source code the paths. 
