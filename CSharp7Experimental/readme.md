# C# 7 Experimental Code Samples

## Introduction

I use these simple code samples to demonstrate experimental features in
Visual Studio "15" preview.

**Note:** You can use *C# Interactive* to demo the C# 7 features, too. To launch
C# interactive with some experimental features enabled, run `csi /features:patterns`.


## Content

* [LocalFunctionLambda](LocalFunctionLambda) demonstrates some local functions using
  lambda expressions. [LocalFunction](LocalFunction) implements the same, but this
  time with the new C# 7 *local functions* feature. During demos, I use `ILDasm`
  to dig deeper into the implementation details. I also demonstrate the differences
  regarding the *Garbage Collector* in case of many calls to a local function.

* [PatternMatching](PatternMatching) contains samples for the new *Pattern Matching*
  feature of C#.

* [RefReturns](RefReturns) contains a sample demonstrating the new ref return Feature
  of C# 7. During demos, I use `ILDasm` to dig deeper into the implementation details.

* [Tuples](Tuples) contains a sample demonstrating tuples in C# 7. At the time of writing,
  tuples are not part of VS "15" Preview. I use this sample to show how you can clone
  the Roslyn GitHub repository, build the sources and run an experimental version of `csc`.


## Considerations

Conference sessions are always time-limited, so I cannot cover everything. I decided 
to focus on the features that are included in VS "15" preview.

C# 7 is still under development. Therefore, the features might be changed, extended,
or removed until the final version of VS "15" comes out. Take a look at
[C# Feature Status](https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md)
to learn more about the status of C# language features.
