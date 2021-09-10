using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static void Main ()
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine (response.StatusDescription);


            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream ();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader (dataStream);


            // Read the content.
            string responseFromServer = reader.ReadToEnd ();

            // Display the content.
            Console.WriteLine (responseFromServer);
            Console.WriteLine("\n");

            // Cleanup the streams and the response.
            reader.Close ();
            dataStream.Close ();
            response.Close ();

            string[] comma = responseFromServer.Split(',');

            string newString = "";

            foreach (var item in comma)
	        {
	        	if (item.Contains("N\\/A") || item.Contains("-") || item.Contains("\"\"") )
	        	{
	        		if (item.Contains("{"))
	        		{
	        			string[] substring = item.Split('{');
	        			foreach (var word in substring)
	        			{
	        				if (word.Contains("N\\/A") || word.Contains("-") || word.Contains("\"\"") )
	        				{
	        					
	        				}
	        				else
	        					newString = newString + word + '{';
	        			}

	        		}
	        		else if (item.Contains("]"))
	        		{
	        			string[] substring = item.Split(']');
	        			foreach (var word in substring)
	        			{
	        				if (word.Contains("N\\/A") || word.Contains("-") || word.Contains("\"\"") )
	        				{
	        					
	        				}
	        				else{
	        					if(newString.EndsWith(",")){
	        						newString = newString.Remove(newString.Length - 1, 1);
	        						newString = newString + word + "],";
	        					}
	        				}
	        			}
	        		}
	        		Console.WriteLine(item);
	        	}
	        	else
	        		newString = newString + item+ ",";
	        }
	        if(newString.EndsWith(",")){
	        	newString = newString.Remove(newString.Length - 1, 1);
	        }
	        Console.WriteLine("\n");
	        Console.WriteLine(newString);
        }
    }
}




































