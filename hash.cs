// Compile this:
// C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /t:exe /out:hash.exe hash.cs

using System;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, string> hashes = new Dictionary<string, string>();
        
        Console.WriteLine("Inicio");

	    StreamReader readFile = new StreamReader(@".\md5_checksums.csv");
        string line;
        string[] row;
        readFile.ReadLine();
        while ((line = readFile.ReadLine()) != null)
            {
                  
                // Console.WriteLine("A  " + line);
                row = line.Split(',');
                var x=row[2].Replace(@"""","");
                var y=row[1].Replace(@"""","");
                // x = x.Replace(@"C:\Program Files (x86)\Microsoft Office\Office12\","");
                hashes.Add( x , y );

                //Console.WriteLine(x + " " + y);
                  
            }
        readFile.Close();
         
	
        // hashes.Add("c:\\camara\\test12345.pfx" , "6B-D0-3F-93-44-21-29-0C-C2-1C-B8-64-6F-E2-E5-CC");

        Console.WriteLine("Comprobando");


        var fallos = 0;

        var allfiles = Directory.GetFiles("C:\\Program Files (x86)\\Microsoft Office\\Office12", "*.*", SearchOption.AllDirectories);
        //Console.WriteLine("Lineas");
        foreach (var file in allfiles)
        {
            
            //Console.WriteLine(file);
            using (var md5 = MD5.Create())
              {
                using (var stream = File.OpenRead(file))
                {
                    var ha = BitConverter.ToString( md5.ComputeHash(stream)).Replace("-","") ;
                    // Console.WriteLine( (file) + " - " + ha );
                    

                    if (hashes.ContainsKey(file))
                    {
                        
                        //Console.WriteLine("Contain Key " + file );
                    
                    

                        if ( (hashes[file] ==  ha )) 
                        {
                        /*
                           Console.WriteLine("Igual " + file);
                           Console.WriteLine( hashes[file]);
                           Console.WriteLine( ha ) ;
                        */
                        
                        }
                        else
                        {
                            fallos +=1;
                            Console.WriteLine("Diff: " + file);
                            Console.WriteLine( hashes[file]);
                            Console.WriteLine( ha ) ;
                        }
                    }else{
                        if (args.Length > 0)
                            {
                                
                                Console.WriteLine( "Not in list : " + (file) + " - " + ha );
                            }
                        
                    }

                  
                }
              }  

         }
           if (fallos == 0)
                    {
                        Console.WriteLine( "Todos los ficheros comprobados bien");
                    }
    }  
}