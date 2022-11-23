using System;

namespace CodeSnippets{
    
    public class CodeSnippets{

        /// <summary>
        /// converts the given string into an array of characters
        /// reverses the order of the array and converts all characters to lowercase
        /// checks if the reversed array(all characters converted to lowercase) is the same with given string(everything converted to lowercase)
        /// returns the result as bool
        /// short summary: checks if the given string and its reversed version are the same, returns the result as bool
        /// </summary>
        static bool function1(string pattern) {
            var parts = pattern.ToCharArray();
            Array.Reverse(parts);
            var starp = (new string(parts)).ToLower();
            
            var b = pattern.ToLower().Equals(starp);
            return b;
        }
        
        
        /// <summary>
        /// recieves an array of integers as arguement
        /// 
        /// </summary>
        public static int function2(int[] numbers){
            for (var h = numbers.Length / 2; h > 0; h /= 2)
            {
                for (var i = h; i < numbers.Length; i += 1)
                {
                    var temp = numbers[i];
                    int t;
                    for (t = i; t >= h && numbers[t - h] > temp; t -= h)
                    {
                        numbers[t] = numbers[t - h];
                    }
                    numbers[t] = temp;
                }
            }
            return 0;
        }
    }
}