#MIPS Processor Simulator#

###**Class:** CS 312 &ndash; Introduction to Organization and Architecture.###

**Program Description:** Processor simulator that reads in binary files and parses them into assembly code instructions.Another important thing is it checks for hazards that are found in a pipeline processor (e.g. Read before write, write before read, etc..).

**Comments:** This was one of the first projects where I started thinking like an object oriented programmer. To keep some order we decided to make an object to encapsulate [the various instructions types](http://en.wikipedia.org/wiki/MIPS_instruction_set#MIPS_I_instruction_formats) while abstracting the processor. I made an Instruction class that was originally supposed to be the superclass for the R, I, and J instructions but I had some issues getting it to work. Under the MIPS Project 2 folder you can see my attempt commented out in the instruction.h file. In the end I had to settle with making a single class that set flags to indicate which type of instruction it was. I was still very happy I finally had a solid example of how to use polymorphism to simplify the organization of my code. The memory.h header contains data abstractions for the buffers, cache and queues used in this architecture. Finally, main.cpp is the driver and handles I/O of the binary files to ascii output files. The dis.txt output files are a listing of [MIPS assembly language instructions](http://en.wikipedia.org/wiki/MIPS_instruction_set#MIPS_assembly_language). The pipeline.txt files display a snapshot of the state of the registers, buffers and cache at a given cycle.

Here is an abstract flow chart of how the processor would handle our MIPS instructions.
![](processor.jpg)

**To run:** I have only run this on a windows machine, but there should be no issues on Linux, probably not Mac.

1. Download the distribution based on the operating system you use.
	1. Download [Sim Program Executable.zip](https://drive.google.com/file/d/0Bwi6Jnp9m7pQcm5XaHB0bEd3dmc/view?usp=sharing).
	2. Unzip the file and go into the Sim Program Executable folder.
	3. Execute mipssim.exe with the arguments -i [inputfile] -o [outputfile] where [inputfile] maps to one of the .bin files and [outputfile] is the name to be added to the _dis.txt and _pipeline.txt files.(ex. mipssim.exe -i t1.bin -o t1). <br/> **NOTE**: -o [outputfile] parameter is optional and will use the name of the binary file if not present.

This will output two files. One file ending with "_dis.txt"is simply the processed instruction being displayed as a binary string and human readable MIPS instruction. The file ending with "_pipeline.txt" displays the states of each piece of the processor at different clock cycles.

For more information look at the files explaining the assignment. It was broken up into two assignments.

- [Project 1](https://github.com/brianolsen87/SIUE-Projects/blob/master/CS%20312%20-%20Intro%20to%20Computer%20Organization%20and%20Architecture/MIPS%20Sim%20Program%20Part%201%20Submission/Project_1.pdf) (interpreting the instructions).
- [Project 2](https://github.com/brianolsen87/SIUE-Projects/blob/master/CS%20312%20-%20Intro%20to%20Computer%20Organization%20and%20Architecture/MIPS%20Sim%20Program%20Part%202%20Submission/project2.pdf) (simulating the pipeline and caching).

