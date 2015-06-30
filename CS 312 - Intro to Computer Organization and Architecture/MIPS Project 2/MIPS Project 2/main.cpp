//CS 312
//Dr. Mark McKenney
//
//MIPS Simulator Project 2
//Brian Olsen
//Brenden Lehman
//Drew Mahan
#include <math.h>
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <iomanip>
#include <string>
#include <fstream>
#include <sstream>
#include "Instruction.h"
#include "Memory.h"

using namespace std;
using namespace InstructionNS;
using namespace MemoryNS;

string intToBin(int num);
void dissembledFile(stringstream& stream,Instruction instr);
bool instructionFetch(Instruction* instr);
void issue(bool isSecondInstr);
void aluUnit();
void memUnit();
void writeBackUnit();
void pipelineFile(stringstream& stream);

bool POST_BREAK = false, STALL = false, INSTRUCTINBUFFER=false;
int REGISTERS[32]={0};
int PC=96, CYCLE=1;
Instruction* INSTRUCT = NULL;
Instruction* HEAD=NULL;//head of linked list for instructions
Instruction* MAGIC = NULL;
Memory MEM;

int main(int argc,char* argv[]){
        char buffer[4];
        int i,amt = 4,cycle=1,index=0;
        char * iPtr = (char*)(void*) &i;
		string inFile="t1",outFile=inFile;
		stringstream outDis, outPipe;
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

						if(PC==96){
						HEAD = MEM.HEAD = INSTRUCT = new Instruction(intToBin(i),NULL);
						HEAD->memaddress=PC;
						dissembledFile(outDis,*(INSTRUCT));
						}
						else{	 
						Instruction* temp = new Instruction(intToBin(i),NULL);
						temp->memaddress=PC;
						dissembledFile(outDis,*temp);	//as look runs through the dissembled File populates instructions, outDat, and data
						INSTRUCT->next=temp;
						INSTRUCT=temp;
						temp=NULL;
						}
				}
        }
		fclose(FD);
		PC=96;
		POST_BREAK = false;
		INSTRUCT=HEAD;
		while(!POST_BREAK || INSTRUCTINBUFFER){	
			pipelineFile(outPipe);//runs the simulation and writes it to outPipe
		}
		fout.open(outFile + "_dis.txt");
		if ( !fout.is_open() ) {
			cerr << "Error writing to output file. Aborting!" << endl;
			exit(1);
		}
			fout << outDis.str();
			fout.close();
		
		fout.open(outFile + "_pipeline.txt");
		if ( !fout.is_open() ) {
			cerr << "Error writing to output file. Aborting!"
				 << endl;
			exit(1);
		}
			fout << outPipe.str();
			fout.close();

			Instruction* del=HEAD;
			
			while(HEAD!=INSTRUCT){ //Destructor for pointers
				HEAD=HEAD->next;
				del->next=NULL;
				delete del;
				del=HEAD;
			}
			HEAD = INSTRUCT = del = NULL;
			
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
void dissembledFile(stringstream& stream,Instruction instr){
	
	if(!POST_BREAK){

	stream << left << setw(2) << instr.validbit << setw(6) << instr.opcode << setw(6) << instr.rs << setw(6) << instr.rt << setw(6)
		   << instr.rd << setw(6) << instr.sa << setw(8) << instr.fcn << setw(4) << PC
		   << instr.checkInstruction() << "\n";
			if(instr.checkInstruction()=="BREAK"){
				POST_BREAK=true;
			}
	}

	else{
	if(MEM.VAR==0){
		MEM.TOP=PC;
		MEM.VAR++;
	}
	stream << left << setw(36) << instr.instruction << setw(4) << PC  << instr.INSTRUCTION_Str() << "\n";
	MEM.DATA[MEM.indexOfMem(PC)]=instr.INSTRUCTION_Int();
	MEM.BOT=PC;
	}

	instr.memaddress=PC;
	
	PC+=4;
	
}
bool instructionFetch(Instruction* instr){//returns if STALL is true or false
	bool jumpOrBranch=false;
	
		if(!POST_BREAK && !MEM.preIssueBuffer[3]!=NULL && MEM.cacheCheck(instr->memaddress)){

				if(instr->fcn=="001101"){//BREAK
					POST_BREAK=true;
					STALL=true;
					writeBackUnit();
				 }
				else if(instr->instruction=="10000000000000000000000000000000"){//NOP
				}
				else if(instr->opcode=="00010"|| instr->opcode=="00001" || 
				   instr->opcode=="00100" || (instr->opcode=="00000" && instr->fcn=="001000")){
							jumpOrBranch=true;
				}
				else if(!MEM.preIssueFull && MEM.SetPreIssue(instr)){//sets the instruction in PreIssue buffer
				PC+=4;
				INSTRUCT=INSTRUCT->next;
				instr->wasMoved=true;
				}
				else{
					MEM.preIssueFull=false;
					STALL=true;
				}
		}//end cacheCheck if
		else if(!MEM.preIssueBuffer[3]!=NULL){
			instr->cacheMiss=true;
			STALL=true;
		}
		if(jumpOrBranch){
			bool useJump=true;
		for(int bufferIndex=0;bufferIndex<=3;bufferIndex++){

		if(MEM.preIssueBuffer[bufferIndex]!=NULL && //Branch Hazard Checking for Preissue Buffer
			(instr->RS_Int() == MEM.preIssueBuffer[bufferIndex]->dest || instr->RT_Int() == MEM.preIssueBuffer[bufferIndex]->dest )){
				useJump=false;
		}
		if(MEM.preAluQueue[bufferIndex]!=NULL && //Branch Hazard Checking for PreAlu Buffer
			(instr->RS_Int() == MEM.preAluQueue[bufferIndex]->dest || instr->RT_Int() == MEM.preAluQueue[bufferIndex]->dest )){
				useJump=false;
		}
		if(MEM.preMemQueue[bufferIndex]!=NULL && //Branch Hazard Checking for PreMem Buffer
			(instr->RS_Int() == MEM.preMemQueue[bufferIndex]->dest || instr->RT_Int() == MEM.preMemQueue[bufferIndex]->dest )){
				useJump=false;
		}//end Branch Hazard Checking
		}
		if(useJump && !POST_BREAK){

			if(instr->fcn=="001000"){//JR
					PC=REGISTERS[instr->RS_Int()];
			}
			else if(instr->opcode=="00100"){//BEQ
				if(REGISTERS[instr->RT_Int()]==REGISTERS[instr->RS_Int()]){
					PC+=(instr->IMM_Int()<<2);
				}
			}
			else if(instr->opcode=="00001"){//BLTZ
				if(REGISTERS[instr->RS_Int()]<0){
					PC+=(instr->IMM_Int()<<2);
				}
			}
			else if(instr->opcode=="00010"){//J
				PC=(instr->JUMP_Int()<<2)-4;
			}

			INSTRUCT=HEAD;
			while(INSTRUCT->memaddress<=PC || INSTRUCT->checkInstruction()=="INVALID INSTRUCTION"){
				INSTRUCT=INSTRUCT->next;
			}
			PC=INSTRUCT->memaddress;
			if(!MEM.cacheCheck(INSTRUCT->memaddress) && INSTRUCT->opcode!="00010"){
			INSTRUCT->cacheMiss=true;
			}
			STALL=true;
		}
		}

	return STALL;
}
void issue(bool isSecondInstr){//HAZARD CHECKER!!
	bool isAlu=false, useInstr=false;
	int index=0, instrCount=0;
	Instruction* instr = MEM.GetPreIssue(index,false);

	while(instr!=NULL && instrCount<=3){
		useInstr=true;

		if(instr->opcode=="00000" && (instr->fcn=="100000"||instr->fcn=="100100"||instr->fcn=="100101"||instr->fcn=="000000"||
			instr->fcn=="000010"||instr->fcn=="100010"||instr->opcode=="11100")){//ADD,AND,OR,SLL,SRL,SUB,MUL
			isAlu=true;
		}
		else if(instr->opcode=="01000"){//ADDI
			isAlu=true;
		}
		if(instr->opcode=="01011"||instr->opcode=="00011"){//SW,LW
			isAlu = false;
		}

		for(int preBufferIndex=index-1;preBufferIndex>=0;preBufferIndex--){//tests within preissue buffer with second instr
			if(MEM.preIssueBuffer[preBufferIndex]!=NULL && instr->memaddress != MEM.preIssueBuffer[preBufferIndex]->memaddress &&
				(instr->dest == MEM.preIssueBuffer[preBufferIndex]->dest || instr->dest == MEM.preIssueBuffer[preBufferIndex]->srcRS || 
				instr->dest == MEM.preIssueBuffer[preBufferIndex]->srcRT || instr->srcRS == MEM.preIssueBuffer[preBufferIndex]->dest || 
				instr->srcRT == MEM.preIssueBuffer[preBufferIndex]->dest)){
					useInstr=false;
			}
			if(!isAlu && MEM.preIssueBuffer[preBufferIndex]!=NULL && MEM.preIssueBuffer[preBufferIndex]->opcode=="01011"){
				useInstr=false;
			}
		}

		for(int bufferIndex=0;bufferIndex<=1;bufferIndex++){

			if(MEM.preAluQueue[bufferIndex]!=NULL &&
				(instr->dest == MEM.preAluQueue[bufferIndex]->dest || /*instr->dest == MEM.preAluQueue[bufferIndex]->srcRS ||*/ 
				/*instr->dest == MEM.preAluQueue[bufferIndex]->srcRT ||*/ instr->srcRS == MEM.preAluQueue[bufferIndex]->dest || 
				instr->srcRT == MEM.preAluQueue[bufferIndex]->dest)){
				useInstr=false;
			}
			if(MEM.preMemQueue[bufferIndex]!=NULL && 
				(instr->dest == MEM.preMemQueue[bufferIndex]->dest  || instr->dest == MEM.preMemQueue[bufferIndex]->srcRS || 
				instr->dest == MEM.preMemQueue[bufferIndex]->srcRT || instr->srcRS == MEM.preMemQueue[bufferIndex]->dest || 
				instr->srcRT == MEM.preMemQueue[bufferIndex]->dest)){
				useInstr=false;
			}
			if(MEM.postAluBuffer!=NULL && (instr->dest == MEM.postAluBuffer->dest  || instr->dest == MEM.postAluBuffer->srcRS || 
				instr->dest == MEM.postAluBuffer->srcRT || instr->srcRS == MEM.postAluBuffer->dest || 
				instr->srcRT == MEM.postAluBuffer->dest)){
					   useInstr=false;
				
			}
			
			if(MEM.postMemBuffer!=NULL && (instr->dest == MEM.postMemBuffer->dest  || instr->dest == MEM.postMemBuffer->srcRS || 
				instr->dest == MEM.postMemBuffer->srcRT || instr->srcRS == MEM.postMemBuffer->dest || 
				instr->srcRT == MEM.postMemBuffer->dest)){
					   useInstr=false;
			}
		
		}//End For
		if(useInstr){
			if(isAlu && instr!=NULL && MEM.SetPreALU(instr)){
				instr->wasMoved=true;
				MEM.GetPreIssue(index,true);
				}
			else if( !isAlu && instr!=NULL && MEM.SetPreMem(instr)){
				instr->wasMoved=true;
				MEM.GetPreIssue(index,true);
				}
		instr = MEM.GetPreIssue(index,false);
		}
		else{
			index++;
			instr = MEM.GetPreIssue(index,false);
		}
		instrCount++;
	}//End While

}
void aluUnit(){
	for(int bufferIndex=0;bufferIndex<=1;bufferIndex++){

	if(MEM.preAluQueue[bufferIndex]!=NULL){
	Instruction* instr=MEM.preAluQueue[bufferIndex];
	if(!instr->wasMoved){
	MEM.SetPostALU(MEM.GetPreALU());
	instr->wasMoved=true;
	}
		if(instr->fcn=="100000"){ //ADD
		instr->value=REGISTERS[instr->RS_Int()]+REGISTERS[instr->RT_Int()];
		}
		else if(instr->fcn=="100100"){//AND
		instr->value=REGISTERS[instr->RS_Int()]&REGISTERS[instr->RT_Int()];
		}
	    else if(instr->fcn=="100101"){//OR
		instr->value=REGISTERS[instr->RS_Int()]^REGISTERS[instr->RT_Int()];
		}
		else if(instr->fcn=="000000"){//SLL      
		instr->value=(REGISTERS[instr->RT_Int()]<<instr->SA_Int());
		}
		else if(instr->fcn=="000010"){//SRL
		instr->value=(REGISTERS[instr->RT_Int()]>>instr->SA_Int());
		}
		else if(instr->fcn=="100010"){//SUB
		instr->value=REGISTERS[instr->RS_Int()]-REGISTERS[instr->RT_Int()];
		}
		if(instr->opcode=="01000"){//ADDI
		instr->value=instr->IMM_Int()+REGISTERS[instr->RS_Int()];
		}
		else if(instr->opcode=="11100"){//MUL
		instr->value=(REGISTERS[instr->RS_Int()])*(REGISTERS[instr->RT_Int()]);
		}
	}
	}
}
void memUnit(){
		if(MEM.preMemQueue[0]!=NULL){
			Instruction* instr=MEM.preMemQueue[0];
			if(instr!=NULL && !instr->wasMoved){
				instr->wasMoved=true;
				if(instr->opcode=="00011" && (MEM.cacheCheck(instr->IMM_Int()+REGISTERS[instr->RS_Int()]) || instr->cacheMiss)){//LW
					instr->value=MEM.DATA[MEM.indexOfMem(instr->IMM_Int()+REGISTERS[instr->RS_Int()])];
					MEM.SetPostMem(MEM.GetPreMem());
					Instruction* iter=HEAD;
					int lWaddress=instr->IMM_Int()+REGISTERS[instr->RS_Int()];

					while(iter->memaddress!=lWaddress){
						iter=iter->next;
					}
					MEM.setCache(*iter); 
					iter=NULL;
					instr->cacheMiss=false;
				}
				else if(instr->opcode=="00011"){
					instr->cacheMiss=true;
				}
				if(instr->opcode=="01011" && (MEM.cacheCheck(instr->IMM_Int()+REGISTERS[instr->RS_Int()]) || instr->cacheMiss)){//SW
					MAGIC=HEAD;
					int lwaddress=(instr->IMM_Int()+REGISTERS[instr->RS_Int()]);
					while(MAGIC->memaddress!=lwaddress){
						MAGIC=MAGIC->next;
					}
					MAGIC->wasMoved =true;
					MAGIC->value=REGISTERS[instr->RT_Int()];
					MAGIC->instruction=intToBin(MAGIC->value);
					MEM.setCache(*MAGIC);
					MEM.changeDirtyBit(MAGIC->memaddress);
					MEM.GetPreMem();
					if(POST_BREAK){
						MEM.DATA[MEM.indexOfMem(MAGIC->memaddress)]=MAGIC->value;
						MEM.changeDirtyBit(MAGIC->memaddress);
					}
					instr->cacheMiss=false;
				}
				else if(instr->opcode=="01011"){
					instr->cacheMiss=true;
				}
			}
		}
}
void writeBackUnit(){
	
	if(MEM.postMemBuffer!=NULL && !MEM.postMemBuffer->wasMoved){
		Instruction* instr = MEM.GetPostMem();
		if(instr->opcode=="00011"){//LW
		REGISTERS[instr->RT_Int()]=instr->value;
		}
		MEM.GetPostMem();
	}
	else if(MEM.postAluBuffer!=NULL && !MEM.postAluBuffer->wasMoved){
		Instruction* instr = MEM.GetPostALU();
		if(instr->opcode=="01000"){//ADDI
		REGISTERS[instr->RT_Int()]=instr->value;
			}
		else{
		REGISTERS[instr->RD_Int()]=instr->value;
		}
		MEM.GetPostALU();
	}
	else if(MAGIC!=NULL && !MAGIC->wasMoved){
		bool update;
		if((MEM.preMemQueue[0]!=NULL && MEM.preMemQueue[0]->opcode=="01011" && MEM.preMemQueue[0]->cacheMiss) || POST_BREAK){
			update=true;
		}
		else{
			update=false;
		}
		
		if(update){
		MEM.DATA[MEM.indexOfMem(MAGIC->memaddress)]=MAGIC->value;
		MEM.changeDirtyBit(MAGIC->memaddress);
		MAGIC=NULL;
		}
	}

}

void pipelineFile(stringstream& stream){
//--------------------------------------------------------SIMULATION------------------------------------------------------------------
	writeBackUnit();
	aluUnit();
	memUnit();
	issue((bool)0);
	if(INSTRUCT->cacheMiss){//if the instruction isn't located in the cache it will be delayed for one clock cycle and set 
				MEM.setCache(*INSTRUCT);
				INSTRUCT->cacheMiss=false;
			}

	for(int i=0; i<=1 && !STALL ;i++){
		 instructionFetch(INSTRUCT);
	}

//--------------------------------------------------------OUTPUT------------------------------------------------------------------
	stream << left << "--------------------" << endl << "Cycle:" << CYCLE << endl << endl;

		//----------------------------------------- BUFFER/QUEUE DISPLAY-------------------------------------

	stream << "Pre-Issue Buffer: " << endl;
	for(int bufferIndex = 0; bufferIndex <= 3; bufferIndex++){
		stream << "\t Entry " << bufferIndex << ":" ;
			if(MEM.preIssueBuffer[bufferIndex] != NULL){
				stream << "\t[" << MEM.preIssueBuffer[bufferIndex]->checkInstruction() << "]";
			}
			stream << endl;
	}
	stream << "Pre_ALU Queue: " << endl;
	for(int bufferIndex = 0; bufferIndex <= 1; bufferIndex++){
		stream << "\t Entry " << bufferIndex << ":" ;
			if(MEM.preAluQueue[bufferIndex] != NULL){
				stream << "\t[" << MEM.preAluQueue[bufferIndex]->checkInstruction() << "]";
			}
			stream << endl;
	}
	stream << "Post_ALU Queue: " << endl;
		stream << "\t Entry 0:" ;
			if(MEM.postAluBuffer != NULL){
				stream << "\t[" << MEM.postAluBuffer->checkInstruction() << "]";
			}
			stream << endl;
	stream << "Pre_MEM Queue: " << endl;
	for(int bufferIndex = 0; bufferIndex <= 1; bufferIndex++){
		stream << "\t Entry " << bufferIndex << ":" ;
			if(MEM.preMemQueue[bufferIndex] != NULL){
				stream << "\t[" << MEM.preMemQueue[bufferIndex]->checkInstruction() << "]";
			}
			stream << endl;
	}
	stream << "Post_MEM Queue: " << endl;
		stream << "\t Entry 0:" ;
			if(MEM.postMemBuffer != NULL){
				stream << "\t[" << MEM.postMemBuffer->checkInstruction() << "]";
			}
			stream << endl;

		//-----------------------------------------REGISTER DISPLAY------------------------------------------


		 stream << endl << "Registers: " << endl;

		for(int i=0;i<=3;i++){ //rows x 4
			stream << "r" << setfill('0') << setw(2) << right << (i*8) << ":    ";
			for(int j=0;j<=7;j++){ //cols x 8
				stream << setw(3) << setfill(' ') << REGISTERS[(i*8)+j] << "  ";
			}
			stream << endl;
		}

		//-----------------------------------------CACHE DISPLAY------------------------------------------

		stream << endl << "Cache" << endl;

		for(int setindex=0; setindex<=3; setindex++){
			stream << "Set " << setindex << ": LRU=" << (int)MEM.cache.set[setindex].lruBit << endl;
			for(int entryindex=0;entryindex<=1; entryindex++){
				stream << "\t" << "Entry " << entryindex << ": [(" 
					   << (int)MEM.cache.set[setindex].entry[entryindex].validBit << ","
					   << (int)MEM.cache.set[setindex].entry[entryindex].dirtyBit << ","
					   << MEM.cache.set[setindex].entry[entryindex].tag << ")<";
				for(int dataindex=0;dataindex<=1; dataindex++){
					if(MEM.cache.set[setindex].entry[entryindex].Data[dataindex].instruction== ""){
						stream << "00000000000000000000000000000000";
					}
					stream << MEM.cache.set[setindex].entry[entryindex].Data[dataindex].instruction;
					if(dataindex==0){
						stream << ",";
					}
				}
				stream << ">]" << endl;
			}
			
		}

		//-----------------------------------------DATA DISPLAY------------------------------------------

		stream << endl << "Data:" << endl;
		
		MEM.VAR=MEM.BOT-MEM.TOP; 
		for(int h=MEM.TOP;h<=MEM.BOT;h+=32){
			stream << h << ":\t";
			if(MEM.VAR>=32){
			for(int i=h; i<=h+28;i+=4){
				stream << setw(3) << setfill(' ') << MEM.DATA[MEM.indexOfMem(i)] << " ";
			}
			}
			else{
			for(int i=h; i<=h+MEM.VAR;i+=4){
				stream << setw(3) << setfill(' ') << MEM.DATA[MEM.indexOfMem(i)] << " ";
			}
			}
			MEM.VAR-=32;
			stream << endl;
		}

//--------------------------------------------------------POST SIMULATION UPDATES------------------------------------------------------------------

		CYCLE++;
		
		STALL=false;
		INSTRUCTINBUFFER = false;
		for(int i=0;i<=3;i++){
			if(i<=1 && MEM.preAluQueue[i]!=NULL){
				MEM.preAluQueue[i]->wasMoved=false;
				INSTRUCTINBUFFER = true;
			}
			if(i<=1 && MEM.preMemQueue[i]!=NULL){
				MEM.preMemQueue[i]->wasMoved=false;
				INSTRUCTINBUFFER = true;
			}
			if(MEM.preIssueBuffer[i]!=NULL){
				MEM.preIssueBuffer[i]->wasMoved=false;
				INSTRUCTINBUFFER = true;
			}
		}
			if(MEM.postAluBuffer!=NULL){
				MEM.postAluBuffer->wasMoved=false;
			}
			if(MEM.postMemBuffer!=NULL){
				MEM.postMemBuffer->wasMoved=false;
			}
		if(MAGIC!=NULL){
			MAGIC->wasMoved=false;
		}
		if(INSTRUCT!=NULL){
			INSTRUCT->wasMoved=false;
		}
}
