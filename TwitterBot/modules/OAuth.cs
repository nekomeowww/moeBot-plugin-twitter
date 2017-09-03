using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using TwitterBot;
using Tweetinvi;
using Tweetinvi.Models;

namespace moeBot_plugin_twitter.modules.OAuth
{
    static class OAuth
    {
        public static string applicationPath = "C:\\Users\\fanff\\Documents\\GitHub\\moeBot\\moeBot\\bin\\Debug";
        public static void Run()
        {
            //string path = InternalCall.GetPath();
            string path = applicationPath;
            path = Path.Combine(path, "token.txt");
            
            //TwitterController tweet = new TwitterController();

            FileUltilities fu = new FileUltilities();
            bool tokenExist = fu.FileExsit(path);

            /*
            if(tokenExist == true)
            {
                //try
                //{
                string newPath = path;
                File.Create(newPath);
                Tools.KeyToFile(newPath, OAuthData());
                //}
                //catch(Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}


            }
            //else
            //{
                //Authentication(ParseToken(path));
                
            //}
            */


            //ITwitterCredentials creds = new TwitterCredentials("CK","CS","AK","ATS");

            Tweetinvi.Tweet.PublishTweet("初めまして よろしくお願いします。</br> by moeBot");
        }

        private static void Authentication(Dictionary<string, string> _Key)
        {
            Tweetinvi.Auth.SetUserCredentials(_Key[KeyNames[0]], _Key[KeyNames[1]], _Key[KeyNames[2]], _Key[KeyNames[3]]);
        }

        private static List<string> OAuthData()
        {
            List<string> OAuthKeys = null;

            Console.WriteLine("Input your Consumer Key: ");
            string CONSUMER_KEY = Console.ReadLine();
            if (CONSUMER_KEY == null)
            { CONSUMER_KEY = Tools.KeyChange(CONSUMER_KEY); }

            Console.WriteLine("Input your Consumer Secret: ");
            string CONSUMER_SECRET = Console.ReadLine();
            if (CONSUMER_SECRET == null)
            { CONSUMER_SECRET = Tools.KeyChange(CONSUMER_SECRET); }

            Console.WriteLine("Input your Access Token: ");
            string ACCESS_TOKEN = Console.ReadLine();
            if (ACCESS_TOKEN == null)
            { ACCESS_TOKEN = Tools.KeyChange(ACCESS_TOKEN); }

            Console.WriteLine("Input your Access Token Secret: ");
            string ACCESS_TOKEN_SECRET = Console.ReadLine();
            if (ACCESS_TOKEN_SECRET == null)
            { ACCESS_TOKEN_SECRET = Tools.KeyChange(ACCESS_TOKEN_SECRET); }

            OAuthKeys.Add(CONSUMER_KEY);
            OAuthKeys.Add(CONSUMER_SECRET);
            OAuthKeys.Add(ACCESS_TOKEN);
            OAuthKeys.Add(ACCESS_TOKEN_SECRET);

            return OAuthKeys;
        }

        private static Dictionary<string, string> ParseToken(string path)
        {
            List<string> lines = null;
            Dictionary<string, string> _Keys = new Dictionary<string, string>();

            foreach(string line in File.ReadLines(path))
            {
                lines.Add(line);
            }

            for(int i = 0; i < lines.Count; i++)
            {
                _Keys.Add(KeyNames[i], lines[i]);
            }

            return _Keys;
        }

        private static string[] KeyNames = { "CK", "CS", "AT", "AS" };
        //private static string CK;
        //private static string CS;
        //private static string AT;
        //private static string AS;
    }

    static class Tools
    {
        public static string KeyChange(string key)
        {
            Console.WriteLine("This line cannot be blank. Input again.");
            key = Console.ReadLine();
            return key;
        }

        public static void KeyToFile(string path, List<string> Token)
        {
            List<string> lines = Token;
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
            System.IO.File.WriteAllLines(path, lines);
        }
    }
}