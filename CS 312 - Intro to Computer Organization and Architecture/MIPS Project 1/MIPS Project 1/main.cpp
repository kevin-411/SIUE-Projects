#include <math.h>
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <iomanip>
#include <string>
#include <fstream>
#include <sstream>

using namespace std;

string intToBin(int num);
bool validateInstruction(char val);
string checkInstruction(string opCode);
void executeInstruction(string opCode, int& mem);
void dissembledFile(stringstream& stream, string str,int& mem);
void simulationFile(stringstream& stream, string str, int& mem, int& cycle);
string binToDec(string str);
int binToInt(string str);
int indexOfMem(int m);
int indexOfIns(int m);

bool POST_BREAK = false;
int REGISTERS[32]={0},DATA[24]={0};
string INSTRUCT[50]={" "};
int TOP=0,BOT=0,VAR=0;

int main(int argc,char* argv[]){
        char buffer[4];
        int i,amt = 4,memory=96,cycle=1,index=0;
        char * iPtr = (char*)(void*) &i;
		string binary,inFile="test1",outFile=inFile;
		stringstream outDis, outSim;
		ofstream fout;

		for(int a=0;a <= argc-1;a++){    //loop to detect command line arguments -i and -o
			string temp=argv[a];
			if(temp=="-i"){
				inFile=argv[a+1];
				outFile=inFile;
			}
			else if(temp=="-o"){
				outFile=argv[a+1];
			}
		}

        FILE* FD = fopen((inFile +".bin").c_str() , "rb"); //file handle for the current binary file

		if(FD==NULL){ //error check to see if the file opened correctly
			cerr << "The file you entered was not found, the program is now exiting." << endl;
			exit(1);
		}

        while( amt != 0 ){                  //loop to run throught the file and write the lines to output streams
            amt = fread(buffer,1,4,FD);
                if( amt == 4){
                        iPtr[0] = buffer[3];
                        iPtr[1] = buffer[2];
                        iPtr[2] = buffer[1];
                        iPtr[3] = buffer[0];
						
						binary=intToBin(i);
						dissembledFile(outDis,binary,memory);	//as look runs through the dissembled File populates instructions, outDat, and data
				}
        }
		fclose(FD);
		memory=92;
		POST_BREAK = false;
		while(!POST_BREAK){
			memory+=4;
			simulationFile(outSim,INSTRUCT[indexOfIns(memory)],memory,cycle);//runs the simulation and writes it to outSim
		}
		fout.open(outFile + "_dis.txt");
		if ( !fout.is_open() ) {
			cerr << "Error writing to output file. Aborting!"
				 << endl;
			exit(1);
		}
			fout << outDis.str();
			fout.close();

		fout.open(outFile + "_sim.txt");
		if ( !fout.is_open() ) {
			cerr << "Error writing to output file. Aborting!"
				 << endl;
			exit(1);
		}
			fout << outSim.str();
			fout.close();

}//end main
string intToBin(int num){
	string temp;

	if(num < 0){
		num=((int)pow(2.0,31)+num);//checks for neg, assigns first int, and changes num to be evaluated
		temp+='1';
	}else{
		temp+='0'; //if not neg first bit is added as 0 and num is unchanged
	}

	for(int i=30;i>=0;i--){ //loop to evaluate and set up the binary string
		if(num-pow(2.0,i) >= 0){
			temp+='1';
			num=num-(int)pow(2.0,i);
		}else{
			temp+='0';
		}
	}
	return temp;
}
bool validateInstruction(char val){//checks the first bit of the string if 1 returns true if 0 returns false
	int temp=val-'0';
	return temp;
}
string checkInstruction(string opCode){//checks the instruction to return appopriate string
	string check=opCode.substr(1,5);
	if(check=="00000"){
		string fcn=opCode.substr(26,6);
		string rs=binToDec(opCode.substr(6,5)),
			   rt=binToDec(opCode.substr(11,5)),
			   rd=binToDec(opCode.substr(16,5)),
			   sa=binToDec(opCode.substr(21,5));
		if(fcn=="100000"){
			return "ADD R"+rd+", R"+rs+", R"+rt;
		}
		else if(fcn=="100100"){
			return "AND R"+rd+", R"+rs+", R"+rt;
		}
		else if(fcn=="001101"){
			POST_BREAK=true;
			return "BREAK";
		}
		else if(fcn=="001000"){
			return "JR  R"+rs;
		}
		else if(fcn=="001010"){
		return "MOVZ    R"+rd+", R"+rs+", R"+rt;
		}
		else if(opCode=="10000000000000000000000000000000"){
			return "NOP";
		}
		else if(fcn=="100101"){
			return "OR R"+rd+", R"+rs+", R"+rt;
		}
		else if(fcn=="000000"){
			return "SLL R"+rd+", R"+rt+", #"+sa;
		}
		else if(fcn=="000010"){
			return "SRL R"+rd+", R"+rt+", #"+sa;
		}
		else if(fcn=="100010"){
		return "SUB R"+rd+", R"+rs+", R"+rt;
		}
		return "Code Not Recognized!\n";
	}
	else if(check=="00010"){
		stringstream jumpOut;
		int jump=binToInt(opCode.substr(6,30));
		jumpOut << jump*4;
		return "J   #"+jumpOut.str();
	}
	else{
		string rs=binToDec(opCode.substr(6,5)),
			   rt=binToDec(opCode.substr(11,5)),
			   rd=binToDec(opCode.substr(16,5)),
			   imm=binToDec(opCode.substr(16,16));

		if(check=="01000"){
			return "ADDI    R"+rt+", R"+rs+", #"+imm;
		}
		else if(check=="00100"){
			return "BEQ R"+rt+", R"+rs+", #"+imm;
		}
		else if(check=="00001"){
			stringstream bltzOut;
			int temp=(binToInt(opCode.substr(16,16))<<2);
			bltzOut << temp;
			return "BLTZ    R"+rs+", #"+bltzOut.str();
		}
		else if(check=="00011"){
			return "LW  R"+rt+ ", " +imm + "(R" + rs + ")";
		}
		else if(check=="11100"){
			return "MUL R"+rd+", R"+rs+", R"+rt;
		}
		else if(check=="01011"){
			return "SW  R"+rt+ ", " +imm + "(R" + rs + ")";
		}
		return "Code Not Recognized!\n";
	}
}
void executeInstruction(string opCode, int& mem){//executes instructions and performs word updates, jumps, etc...
	string check=opCode.substr(1,5);
	if(check=="00000"){
		string fcn=opCode.substr(26,6);
		int rs=binToInt(opCode.substr(6,5)),
			rt=binToInt(opCode.substr(11,5)),
			rd=binToInt(opCode.substr(16,5)),
			sa=binToInt(opCode.substr(21,5));
		if(fcn=="100000"){ //ADD
		REGISTERS[rd]=REGISTERS[rs]+REGISTERS[rt];
		}
		else if(fcn=="100100"){//AND
		REGISTERS[rd]=REGISTERS[rs]&REGISTERS[rt];
		}
		else if(fcn=="001101"){//BREAK
			POST_BREAK=true;
		}
		else if(fcn=="001000"){//JR
			 mem=REGISTERS[rs]-4;
		}
		else if(fcn=="001010"){////MOVZ RS RT RD 0 001010
			if(REGISTERS[rt]==0){
			REGISTERS[rd]=REGISTERS[rs];
			}
		}
		else if(opCode=="10000000000000000000000000000000"){//NOP
		}
		else if(fcn=="100101"){//OR
			REGISTERS[rd]=REGISTERS[rs]^REGISTERS[rt];
		}
		else if(fcn=="000000"){//SLL      
			REGISTERS[rd]=(REGISTERS[rt]<<sa);
		}
		else if(fcn=="000010"){//SRL
			REGISTERS[rd]=(REGISTERS[rt]>>sa);
		}
		else if(fcn=="100010"){//SUB
		    REGISTERS[rd]=REGISTERS[rs]-REGISTERS[rt];
		}
	}
	else if(check=="00010"){//J
		mem=(binToInt(opCode.substr(6,30))<<2)-4;
	}
	else{
		int rs=binToInt(opCode.substr(6,5)),
			rt=binToInt(opCode.substr(11,5)),
			rd=binToInt(opCode.substr(16,5)),
			imm=binToInt(opCode.substr(16,16));
		if(check=="01000"){//ADDI
			REGISTERS[rt]=imm+REGISTERS[rs];
		}
		else if(check=="00100"){//BEQ
			if(REGISTERS[rt]==REGISTERS[rs]){
				mem+=(imm<<2)-4;
			}
		}
		else if(check=="00001"){//BLTZ
			if(REGISTERS[rs]<0){
				mem+=(binToInt(opCode.substr(16,16))<<2);
			}
		}
		else if(check=="00011"){//LW
			REGISTERS[rt]=DATA[indexOfMem(imm+REGISTERS[rs])];
		}
		else if(check=="11100"){//MUL
			REGISTERS[rd]=REGISTERS[rs]*REGISTERS[rt]; 
		}
		else if(check=="01011"){//SW
			DATA[indexOfMem(imm+REGISTERS[rs])]=REGISTERS[rt];
		}
	}
}
void dissembledFile(stringstream& stream,string str,int& mem){

	if(validateInstruction(str.at(0)) && !POST_BREAK){

	stream << left << setw(2) << str.at(0) << setw(6) << str.substr(1,5) << setw(6) << str.substr(6,5) << setw(6) << str.substr(11,5) << setw(6)
		   << str.substr(16,5) << setw(6) << str.substr(21,5) << setw(8) << str.substr(26,6) << setw(4) << mem
		   << checkInstruction(str) << "\n";
	INSTRUCT[indexOfIns(mem)]=str;
	}

	else if(!POST_BREAK){

	stream << left << setw(2) << str.at(0) << setw(6) << str.substr(1,5) << setw(6) << str.substr(6,5) << setw(6) << str.substr(11,5) << setw(6)
		<< str.substr(16,5) << setw(6) << str.substr(21,5) << setw(8) << str.substr(26,6) << setw(4) << mem
		<< "Invalid Instruction" << "\n";
	INSTRUCT[indexOfIns(mem)]="Invalid Instruction";
	}

	else{
	if(VAR==0){
		TOP=mem;
		VAR++;
	}
	stream << left << setw(36) << str << setw(4) << mem  << binToDec(str) << "\n";
	DATA[indexOfMem(mem)]=binToInt(str);
	BOT=mem;
	}
	mem+=4;

}
void simulationFile(stringstream& stream, string str, int& mem, int& cycle){
	if(str!="Invalid Instruction"){
	stream << left << "====================" << endl << "cycle:" << cycle << "    " << mem << " " << checkInstruction(str) << endl
		   << endl << "registers: " << endl;

	executeInstruction(str,mem);

		for(int i=0;i<=3;i++){ //rows x 4
			stream << "r" << setfill('0') << setw(2) << (i*8) << ":    ";
			for(int j=0;j<=7;j++){ //cols x 8
				stream << setw(3) << setfill(' ') << REGISTERS[(i*8)+j] << "  ";
			}
			stream << endl;
		}
		stream << endl << "data:" << endl;
		
		VAR=BOT-TOP; 
		for(int h=TOP;h<=BOT;h+=32){
			stream << h << ":\t";
			if(VAR>=32){
			for(int i=h; i<=h+28;i+=4){
				stream << setw(3) << setfill(' ') << DATA[indexOfMem(i)] << " ";
			}
			}
			else{
			for(int i=h; i<=h+VAR;i+=4){
				stream << setw(3) << setfill(' ') << DATA[indexOfMem(i)] << " ";
			}
			}
			VAR-=32;
			stream << endl;
		}
		stream << endl;
		cycle++;
	}
}
string binToDec(string str){
	stringstream out;
	int num;

	num=binToInt(str);
	
	out << num;//number gets assigned to out stringstream

	return out.str();
}
int binToInt(string str){
	int index=str.length()-1;
	int num=0;

	if(str.at(0)=='1'&& index<=30){
		num-=(int)pow(2.0,index+1);
	}
	for(int i=0; i <= (int)str.length()-1; i++){//loop to traverse the binary string and add up the integer value

		if(str.at(index)=='1'){
			num+=(int)pow(2.0,i);
		}
		index--;
	}
	return num;
}
int indexOfMem(int m){
	return (m-TOP)/4;
}
int indexOfIns(int m){
	return (m-96)/4;
}