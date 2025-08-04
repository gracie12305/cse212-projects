using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    /// 
    /// 
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        //Base case: if n is 0 or a negative, there is nothing to add
        if (n <= 0)
            return 0;

        //This is a recursive case: add n^2 and call function on (n - 1)
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        //Base case: if the word has reached the desired lenght, add to the results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        //Loop through each letter to build permutations
        for (int i = 0; i < letters.Length; i++)
        {
            //Remove the letter at undex i in oerder to avoid repeating it.
            string newLetters = letters.Remove(i, 1);

            //Then add the current letter to 'word'and recure it with the remaining letters
            PermutationsChoose(results, newLetters, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3
        //Create a memerization dictionary if it not already initialized
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s == 0)
            return 1; //meaning there is one way to stay at step 0, there are no steps taken

        if (s < 0)
            return 0; //there is no way to climb negative steps or rather stepd that are not there

        //Then if we have already computed this, return the stored value
        if (remember.ContainsKey(s))
            return remember[s];

        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);

        //store results for future use
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        //First: find the index of the first wildcard '*'
        int index = pattern.IndexOf('*');

        //If no wildcard remains, add the resolved pattern
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        //Replace * with a 0 and recurse

        string withZero = pattern.Substring(0, index) + "0" + pattern[(index + 1)..];
        WildcardBinary(withZero, results);

        //Replay * with a number 1 and recurse
        string withOne = pattern.Substring(0, index) + "1" + pattern[(index + 1)..];
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null)
        {
            currPath = new List<(int, int)>();
        }

        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        // ADD CODE HERE
        // If move is out of bounds, into wall, or already visited, exit
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // Add current position to path
        currPath.Add((x, y));


        // If we're at the end, record the path
        if (maze.IsEnd(x, y))
        {
            // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
            results.Add(currPath.AsString());
        }
        else
        {
            //Explore all directions(right, left, down, up)
            SolveMaze(results, maze, x + 1, y, currPath); //this is to the right
            SolveMaze(results, maze, x - 1, y, currPath); //this is to the left
            SolveMaze(results, maze, x, y + 1, currPath); //this is down
            SolveMaze(results, maze, x, y - 1, currPath); //this is up

        }

        currPath.RemoveAt(currPath.Count - 1); // Backtrack: remove last position to try a new path
    }
}