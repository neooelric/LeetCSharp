# What's this?

This is a LeetCode CSharp Solutions repository.

0. All solution are written by CSharp and tested in my laptop(with dotnet core 3.1), and passed the LeetCode test cases (obviously).
0. For each problem, this repo only offers one solution : not the best, just the normal/main-stream solution. if there is two ways to solve a problem, one is faster but the code logic is kind of twisted and hard to explain, one is slower but the train of thoughts is more unstandable, i'll use the slower one.
0. I'll write the general train of thoughts in each solution code file's top position, except for those really simple problems
0. I'll try my best to write decent and readable code to avoid tedious comments inside method blocks, especially thoses comments just explain the code logic.

# Project Structure

```
RootDirectory
|
\---readme.md                 // the document you're reading now
\---LICENSE                   // License declaration file
\---LeetCSharp.sln            // standard Visual Studio Solution definition file
|
\---Solutions                 // all problems' solutions are under this directory, it's also a standard dotnet core lib project
|   |
|   \---0001.cs                   // named by problem index
|   \---0002.cs
|   \---...
|   \---Solution.csproj           // dotnet core project definition file
|
\---Tests                     // testing code, a standard dotnet core unit-test project using xUnit framework
|   |
|   \---0001.cs                   // testing code also named by problem index
|   \---0001.txt                  // test cases are written as plain text file
|   \---0002.cs
|   \---0002.txt
|   \---...
|   \---Test.csproj               // dotnet core project definition file
|
\---Utilities                 // utilities code, a standard dotnet core lib project
    \---Helper.cs                 // helper functions used by unit-test project, such as parse test-cases text file, compare array or linked-list etc...
    \---LeetCodeDefinitions.cs    // all fundemental data-structure definitions in here, such as ListNode
    \---Utilities.csproj          // dotnet core project definition file
\---CodeSnippets              // code snippets definitions that'll help me to write boring unit-test, you can just ignore this directory
    \---...


```

# Debug & Run code in local environment

Obviously, you should install dotnet core sdk(on Linux/MacOS/Windows) or Visual Studio(on Windows) first.

On windows platform with Visual Studio(I suggest you use the lasted community version, it's totally free) installed, you can simplely double-click `LeetCSharp.sln` open the whole repository in Visual Studio, then do whatever you like : debug/run the unit-test project with some breakpoints to understand the code, or something else.

On other platform, or you just hate the whole bunch shit of Visual Studio, you should at least install the dotnet core sdk, then use whatever text-editor you like to read/edit the code, use following command-line command to run the unit-test

```
> dotnet restore
> dotnet build
> dotnet test
```