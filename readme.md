# What's this?

This is a LeetCode CSharp Solutions repository.

0. all solution are written by CSharp and tested in my laptop(dotnet core 3.1), and passed the LeetCode test cases (obviously).
0. for each LeetCode problem, this repo only offers one solution : not the best, just the normal/main-stream solution.
0. I'll try my best to coding decent and readable code, comments will only occurred in problems that are really complex and difficult.

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