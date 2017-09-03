using moeInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moeBot_plugin_twitter.modules.OAuth;

namespace TwitterBot
{
    public class TwitterBot : IPlugin
    {
        public string Name
        {
            get
            {
                return "Twitter";
            }
        }

        public string shortID
        {
            get
            {
                return "twitter";
            }
        }

        public string compatible_version
        {
            get
            {
                return "(1.0.0";
            }
        }

        public string applicationPath(string path)
        {
            InternalCall.applicationPath = path;
            return path;
        }

        public string Hello()
        {
            return "Twitter is standby";
        }

        public void Start()
        {
            Console.WriteLine("Initializing plugin: " + Name + " ...");
            Twitter.Init();
        }
    }

    class Twitter
    {
        public static void botRun()
        {
            
        }

        public static void Init()
        {
            OAuth.Run();
        }
    }

    public static class InternalCall
    {
        public static string applicationPath = "PLACEHOLDER";
        public static string GetPath()
        {
            string path = applicationPath;
            Console.WriteLine(path);
            return path;
        }
    }
}
