#ifndef INSTRUCTION_H
#define INSTRUCTION_H
#include <iostream>
#include <string>
#include <sstream>

using namespace std;
namespace InstructionNS{
	//-------------------------------------------------------------------------------------
	// Class: Instruction
	//
	// Parent class for a 32 bit MIPS Instruction contained as a string and seperates the opcode and Valid bit
	//-------------------------------------------------------------------------------------
	class Instruction{
	public:
		int memaddress,value,dest,srcRS,srcRT;
		string instruction,
				opcode,
				rs,
				rt,
				rd,
				sa,
				fcn,
				imm,
				jump;
		char validbit;
		Instruction* next;
		bool wasMoved,cacheMiss;

		Instruction(string instruction="",Instruction* next=NULL):wasMoved(false),memaddress(memaddress),value(value),cacheMiss(false),srcRS(srcRS),srcRT(srcRT){
			Instruction::instruction=instruction,		
			opcode=instruction.substr(1,5),
			validbit=instruction.at(0),
			rs=instruction.substr(6,5),
			rt=instruction.substr(11,5),
			rd=instruction.substr(16,5),
			sa=instruction.substr(21,5),
			fcn=instruction.substr(26,6);
			imm=instruction.substr(16,16);
			jump=instruction.substr(6,30);
		}
		int INSTRUCTION_Int(){
			return ToInt(instruction);
		}
		int RS_Int(){
			return ToInt(rs);
		}
		int RT_Int(){
			return ToInt(rt);
		}
		int RD_Int(){
			return ToInt(rd);
		}
		int SA_Int(){
			return ToInt(sa);
		}
		int IMM_Int(){
			return ToInt(imm);
		}
		int JUMP_Int(){
			return ToInt(jump);
		}
		string INSTRUCTION_Str(){
			return ToDec(instruction);
		}
		string RS_Str(){
			return ToDec(rs);
		}

		string RT_Str(){
			return ToDec(rt);
		}

		string RD_Str(){
			return ToDec(rd);
		}

		string SA_Str(){
			return ToDec(sa);
		}

		string IMM_Str(){
			return ToDec(imm);
		}
		string JUMP_Str(){
			return ToDec(jump);
		}
		
		string ToDec(string str) const{
			stringstream out;
			int num;
			num=ToInt(str);
	
			out << num;//number gets assigned to out stringstream

			return out.str();
		}
		int ToInt(string str) const{
			
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
		bool validInstruction(){//checks the first bit of the string if 1 returns true if 0 returns false
			if(validbit=='0'){
				return false;
			}
			return true;
		}
	string checkInstruction(){//checks the instruction to return appopriate string

	if(!validInstruction()){
		return "INVALID INSTRUCTION";
	}
	
	if(opcode=="00000"){

		if(fcn=="100000"){
			dest = RD_Int();
			srcRS = RS_Int();
			srcRT = RT_Int();
			return "ADD R"+RD_Str()+", R"+RS_Str()+", R"+ RT_Str();
		}
		else if(fcn=="100100"){
			dest = RD_Int();
			srcRS = RS_Int();
			srcRT = RT_Int();
			return "AND R"+RD_Str()+", R"+RS_Str()+", R"+RT_Str();
		}
		else if(fcn=="001101"){
			return "BREAK";
		}
		else if(fcn=="001000"){
			dest = -1;
			srcRS = RS_Int();
			srcRT = -1;
			return "JR  R"+RS_Str();
		}
		else if(fcn=="001010"){
		return "MOVZ    R"+RD_Str()+", R"+RS_Str()+", R"+RT_Str();
		}
		else if(instruction=="10000000000000000000000000000000"){
			return "NOP";
		}
		else if(fcn=="100101"){
			dest = RD_Int();
			srcRS = RS_Int();
			srcRT = RT_Int();
			return "OR R"+RD_Str()+", R"+RS_Str()+", R"+RT_Str();
		}
		else if(fcn=="000000"){
			dest = RD_Int();
			srcRS = -1;
			srcRT = RT_Int();
			return "SLL R"+RD_Str()+", R"+RT_Str()+", #"+SA_Str();
		}
		else if(fcn=="000010"){
			dest = RD_Int();
			srcRS = -1;
			srcRT = RT_Int();
			return "SRL R"+RD_Str()+", R"+RT_Str()+", #"+SA_Str();
		}
		else if(fcn=="100010"){
			dest = RD_Int();
			srcRS = RS_Int();
			srcRT = RT_Int();
			return "SUB R"+RD_Str()+", R"+RS_Str()+", R"+RT_Str();
		}
		return "Code Not Recognized!\n";
	}
	else if(opcode=="00010"){
		dest = -1;
		srcRS = -1;
		srcRT = -1;
		stringstream jumpOut;
		jumpOut << (JUMP_Int()<<2);
		return "J   #"+jumpOut.str();
	}
	else{

		if(opcode=="01000"){
			dest = RT_Int();
			srcRS = RS_Int();
			srcRT = -1;
			return "ADDI    R"+RT_Str()+", R"+RS_Str()+", #"+IMM_Str();
		}
		else if(opcode=="00100"){
			dest = -1;
			srcRS = RS_Int();
			srcRT = RT_Int();
			return "BEQ R"+RT_Str()+", R"+RS_Str()+", #"+IMM_Str();
		}
		else if(opcode=="00001"){
			dest = -1;
			srcRS = RS_Int();
			srcRT = -1;
			stringstream bltzOut;
			bltzOut << (IMM_Int()<<2);
			return "BLTZ    R"+RS_Str()+", #"+bltzOut.str();
		}
		else if(opcode=="00011"){
			dest = RT_Int();
			srcRS = RS_Int();
			srcRT = -1; 
			return "LW  R"+RT_Str()+ ", " +IMM_Str() + "(R" + RS_Str() + ")";
		}
		else if(opcode=="11100"){
			return "MUL R"+RD_Str()+", R"+RS_Str()+", R"+RT_Str();
		}
		else if(opcode=="01011"){
			dest = RT_Int();
			srcRS = RS_Int();
			srcRT = -1; 
			return "SW  R"+RT_Str()+ ", " +IMM_Str() + "(R" + RS_Str() + ")";
		}
		return "Code Not Recognized!\n";
	}
}
	};

}
	
#endif

//#ifndef INSTRUCTION_H
//#define INSTRUCTION_H
//#include <iostream>
//#include <string>
//#include <sstream>
//
//using namespace std;
//namespace InstructionNS{
//	//-------------------------------------------------------------------------------------
//	// Class: Instruction
//	//
//	// Parent class for a 32 bit MIPS Instruction contained as a string and seperates the opcode and Valid bit
//	//-------------------------------------------------------------------------------------
//	class Instruction{
//	public:
//		int stage, count;
//		string instruction,
//				opcode;
//		char validbit;
//		
//
//		Instruction(string instruction=""):stage(stage), count(count){
//			Instruction::instruction=instruction,
//			opcode=instruction.substr(1,5);
//		}
//		
//		string ToDec(string str) const{
//			stringstream out;
//			int num;
//			num=ToInt(str);
//	
//			out << num;//number gets assigned to out stringstream
//
//			return out.str();
//		}
//		int ToInt(string str) const{
//			
//			int index=str.length()-1;
//			int num=0;
//
//			if(str.at(0)=='1'&& index<=30){
//				num-=(int)pow(2.0,index+1);
//			}
//			for(int i=0; i <= (int)str.length()-1; i++){//loop to traverse the binary string and add up the integer value
//
//				if(str.at(index)=='1'){
//					num+=(int)pow(2.0,i);
//				}
//				index--;
//			}
//			return num;
//		}
//					
//	};
//	
//	//-------------------------------------------------------------------------------------
//	// Class: R Type Instruction
//	//
//	// Sub class for a 32 bit MIPS Instruction containing all the specific variables and methods for this type
//	//-------------------------------------------------------------------------------------
//	class RType:public Instruction{
//	public:
//		int stage, count;
//		string instruction,
//				opcode,
//				rs,
//				rt,
//				rd,
//				sa,
//				fcn;
//		Instruction* next;
//		char validbit;
//		RType(string instruction){
//			Instruction::instruction=instruction,
//			opcode=instruction.substr(1,5),
//			validbit=instruction.at(0),
//			rs=instruction.substr(6,5),
//			rt=instruction.substr(11,5),
//			rd=instruction.substr(16,5),
//			sa=instruction.substr(21,5),
//			fcn=instruction.substr(26,6);
//		}
//		int RS_Int(){
//			return ToInt(rs);
//		}
//		int RT_Int(){
//			return ToInt(rt);
//		}
//		int RD_Int(){
//			return ToInt(rd);
//		}
//		int SA_Int(){
//			return ToInt(sa);
//		}
//		string RS_Str(){
//			return ToDec(rs);
//		}
//		string RT_Str(){
//			return ToDec(rt);
//		}
//		string RD_Str(){
//			return ToDec(rd);
//		}
//		string SA_Str(){
//			return ToDec(sa);
//		}
//	};
//	//-------------------------------------------------------------------------------------
//	// Class: I Type Instruction
//	//
//	// Sub class for a 32 bit MIPS Instruction containing all the specific variables and methods for this type
//	//-------------------------------------------------------------------------------------
//	class IType:public Instruction{
//	public:
//		int stage, count;
//		string instruction,
//				opcode,
//				rs,
//				rt,
//				imm;
//		char validbit;
//		Instruction* next;
//		IType(string instruction):stage(0){
//			Instruction::instruction=instruction,
//			opcode=instruction.substr(1,5),
//			validbit=instruction.at(0),
//			rs=instruction.substr(6,5),
//			rt=instruction.substr(11,5),
//			imm=instruction.substr(16,16);
//		}
//		int RS_Int(){
//			return ToInt(rs);
//		}
//		int RT_Int(){
//			return ToInt(rt);
//		}
//		int IMM_Int(){
//			return ToInt(imm);
//		}
//		string RS_Str(){
//			return ToDec(rs);
//		}
//		string RT_Str(){
//			return ToDec(rt);
//		}
//		string IMM_Str(){
//			return ToDec(imm);
//		}
//	};
//	//-------------------------------------------------------------------------------------
//	// Class: J Type Instruction
//	//
//	// Sub class for a 32 bit MIPS Instruction containing all the specific variables and methods for this type
//	//-------------------------------------------------------------------------------------
//	class JType:public Instruction{
//	public:
//		int stage, count;
//		string instruction,
//				opcode,
//				jump;
//		char validbit;
//		Instruction* next;
//		JType(string instruction=""):stage(stage){
//			Instruction::instruction=instruction,
//			opcode=instruction.substr(1,5),
//			validbit=instruction.at(0),
//			jump=instruction.substr(6,30);
//		}
//		int JUMP_Int(){
//			return ToInt(jump);
//		}
//		string JUMP_Str(){
//			return ToDec(jump);
//		}
//	};
//	class Node{
//		public:
//			union Item{RType rtype;
//						IType itype;
//						JType jtype;}instruct;
//			Node* previous;
//			Node* next;
//
//			Node(const string instruction, const nodePtr previous, const nodePtr next) 
//				/*: item(instructio), previous(previous), next(next)*/
//			{
//				if(instruction.substr(1,5)=="00000"){
//				
//				}
//				else if(instruction.substr(1,5)=="00010"){
//					
//				}
//			
//			}
//		};