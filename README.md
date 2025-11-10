# Calculator

This is a (kind of) simple calculator program coded in C#.  
It has all the basic functions a normal calculator would, plus a custom square root function based on an old MIT paper you can find [here](https://math.mit.edu/~stevenj/18.335/newton-sqrt.pdf), and a quadratic equation solver.  
The project is currently in its infancy, and will likely undergo major changes very rapidly.  


## Installation

It's easiest to just download precompiled binaries for your operating system [here](https://github.com/T-Perm777/Calculator/releases/latest)  
If you don't want to do that, follow these steps:  

+ Run `git clone https://github.com/T-Perm777/Calculator.git && cd Calculator/src` to clone the repo and cd into the folder with the C# scripts.
+ Next, run `dotnet run` to run the script, which will also compile it to the subfolder bin\Debug\net10.0 (may change depending on .NET version)   


## Usage  

There's currently no flags, so just run the executable file and follow the prompts. As far as I know, if anything is entered incorrectly, there's already error handling in place.  


## Current features:  

+ Addition
+ Subtraction
+ Multiplication
+ Division
+ Square roots
+ Solving quadraic equations


## Future plans:  

+ Ability to evaluate equations in normal calculator format (i.e. 2*4)
+ Ability to evaluate equations with more than one operation
+ Storing the previous answer in `Ans` so that you can perform operations on the previous result
+ Variables
+ Solving for `x` or other variables
+ Mathematical constants
+ Mac & Linux binaries