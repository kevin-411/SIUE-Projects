Compiler: Visual C++ 10.0

Compiler Optimization in Visual Studio (2010)

1) Open		Project > [Project Name] Properties

2) Navigate to 	Configuration Properties > C/C++ > General

3) Change 	"Debug Information Format from (/ZI) to (/Zi)

4) Navigate to	Configuration Properties > C/C++ > Optimization

5) Change	"Optimization" to Full Optimization (/Ox)

6) Change	"Omit Frame Pointers" to Yes (/Oy)

7) Navigate to	Configuration Properties > C/C++ > Code Generation

8) Change	"Basic Runtime Checks" to (Default)

9) Navigate to	Configuration Properties > C/C++ > Language

10)Change	"Open MP Support" to Yes (/openmp)