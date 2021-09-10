using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;

public class WebRequestGetExample
{
    public static void Main ()
    {
        // Create a request for the URL. 		
        WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/age-counting");
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
        // Console.WriteLine (responseFromServer);
        // Console.WriteLine("\n");

        // Cleanup the streams and the response.
        reader.Close ();
        dataStream.Close ();
        response.Close ();

        string[] comma = responseFromServer.Split(',');
        int count = 0;
        foreach (var item in comma)
        {
            if (item.Contains("age"))
            {
                string[] age = item.Split("=");
                foreach (var word in age )
                {
                    if (word.Contains('}'))
                    {
                        if (int.Parse(word[0].ToString()) >= 50)
                        {
                            count+=1;
                        }
                    }
                    else if (!word.Contains("age") &&  (int.Parse(word.ToString()) >= 50))
                    {
                        count+=1;
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
}



























