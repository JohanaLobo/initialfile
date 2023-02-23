//Johana-FileParse Tests
using System;
using System.Linq;
using static TestCase.State;
namespace TestCase {
    class Program {
        public static void Main (string[] args) {
            Queue <string> stests = new Queue<string>();  //enquing some valid/invalid file destinations
            stests.Enqueue ("cd:/program/test.txt".ToUpper ());
            stests.Enqueue ("c:/program/test.txt".ToUpper ());
            stests.Enqueue ("c/program/test.txt".ToUpper ());
            stests.Enqueue ("c:users/test.txt".ToUpper ());
            stests.Enqueue ("d:/test.cs".ToUpper ());
            stests.Enqueue ("s://onedrive/tests.pdf".ToUpper ());
            stests.Enqueue ("d:/documents/test/words/txt".ToUpper ());
            stests.Enqueue ("2e:/hello/form.txt".ToUpper ());
            stests.Enqueue ("r:/newfile/input45.txt".ToUpper ());
            stests.Enqueue ("s:/hp/users/downloads/newfolder.txt".ToUpper ());
            stests.Enqueue ("C:/Users/HP/OneDrive/Documents/PROJECT.pdf".ToUpper ());
            stests.Enqueue ("C:/MYPROJECTFOLDER/WORDSCS");
            
            foreach (var st in stests) {
                bool f1 = IsValid (st);
                Console.ForegroundColor= f1 ? ConsoleColor.Green : ConsoleColor.Red;  // if valid name,highlight green
                Console.Write (f1);
                if (f1) {
                    Console.Write ("--"+ GetTupleMethod (st));  // if valid name,get tuples of four strings
                }
                Console.WriteLine ();
            }
            Console.ResetColor ();

            static bool IsValid (string input) {  // method to check valid file path
                State s = A;
                foreach (var ch in input + "~") {
                    s = (s, ch) switch
                    {
                        (A, >= 'A' and <= 'Z') => B,
                        (B, ':') => C,
                        (C, '/') => D,
                        (D or E, >= 'A' and <= 'Z') => E,
                        (E, '/') => F,
                        (F or G, >= 'A' and <= 'Z') => G,
                        (G, '/') => F,
                        (G, '.') => H,
                        (H or I, >= 'A' and <= 'Z') => I,
                        (I, '~') => J,
                        _ => Z,
                    };
                }
                return s == J;
            }

            static Tuple<string, string, string, string> GetTupleMethod (string input) {  // tuple method,returns 4 string (drive,directories,filename,extension)
                string s1, s2, s3, s4;
                string[] arr = input.Split (':');
                s1 = arr[0];
                string[] arr1 = arr[1].Split ('.');
                s4 = arr1[1];
                string[] arr2 = arr1[0].Split ('/');
                s3 = arr2[arr2.Length - 1];
                s2 = arr1[0].Substring (arr1[0].IndexOf ('/') + 1, arr1[0].LastIndexOf ('/') - 1);

                return new Tuple<string, string, string, string> (s1, s2, s3, s4);
            }
        }
    }
    enum State { A, B, C, D, E, F, G, H, I, J, Z };
}
