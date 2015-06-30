#ifndef MEMORY_H
#define MEMORY_H
#include <iostream>
#include <string>
#include <sstream>
#include "Instruction.h"
#include <queue>

using namespace std;
using namespace InstructionNS;

namespace MemoryNS{

	class Memory{
	public:
		int setBit, entryBit, dataBit,TOP,BOT,VAR;
		int DATA[24];
		bool preIssueFull,preMemFull;
		Instruction* preIssueBuffer[4];
		Instruction* preAluQueue[2];
		Instruction* preMemQueue[2];
		Instruction* postAluBuffer;
		Instruction* postMemBuffer;
		Instruction* HEAD;
		struct Entry{
			bool validBit;
			bool dirtyBit;
			int tag;
			Instruction Data[2];
		};
		struct Set{
			bool lruBit;
			Entry entry[2];
		};
		struct Cache{
		Set set[4];
		};
		Cache cache;
		Memory():setBit(setBit), entryBit(entryBit),dataBit(dataBit),cache(cache),
				 TOP(TOP),BOT(BOT),VAR(VAR),preIssueFull(preIssueFull),preMemFull(preMemFull){
		for(int i=0; i<=23; i++){
			DATA[i]=0;
		}
		for(int i=0; i<=3;i++){
			preIssueBuffer[i]=NULL;
		}
		for(int i=0; i<=1;i++){
			preAluQueue[i]=NULL;
			preMemQueue[i]=NULL;
		}
			postAluBuffer=NULL;
			postMemBuffer=NULL;
			HEAD=NULL;
		}
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
	void setCache(Instruction instr){
			int tempTag;
			bool updateLru=true;
			//----------------------------FIRST INSTRUCTION-----------------------------
			

			int tag=instr.memaddress >> 5;//sets temp variable for tag

			if(instr.memaddress>=128){
				tempTag=(tag>>1)+1;
				setBit=(instr.memaddress>>3&tempTag);//set bit for instruction set
			}

			else{
				setBit=(instr.memaddress>>3&tag);//set bit for instruction set
			}
			if(cacheCheck(instr.memaddress)){
				entryBit = checkCache(instr.memaddress);
				updateLru=false;
				cache.set[setBit].lruBit=!(bool)entryBit;
			}
			else{
				entryBit=(int)cache.set[setBit].lruBit;//assigns the Least Recently Used bit (LRU)
			}
			dataBit=(instr.memaddress>>2&1);//bit that determines first instruction in an entry is used
		
			cache.set[setBit].entry[entryBit].Data[dataBit]=instr;//assigns the first instruction
			cache.set[setBit].entry[entryBit].tag=tag;//assigns the temp tag variable to cache tag
			cache.set[setBit].entry[entryBit].validBit=true;

			if(updateLru){
			if(cache.set[setBit].lruBit){
				cache.set[setBit].lruBit=false;
			}
			else{
				cache.set[setBit].lruBit=true;
			}
			}
			//----------------------------SECOND INSTRUCTION----------------------------
			if(instr.memaddress<BOT){
			int lastSetBit=setBit;
			int lastTag=tag;
			int setBitTest=(instr.next->memaddress>>3)&(instr.next->memaddress>>5);
			int setBitTestHack=(instr.next->memaddress>>3)&(((instr.next->memaddress>>5)>>1)+1);
			if(lastTag==(instr.next->memaddress>>5) && setBit==setBitTest){//compares the tags of the following instruction to see if it is within the same memory block
				tag=(instr.next->memaddress>>5);
				
				setBit=(instr.next->memaddress>>3&tag);//set bit for instruction set
				
				dataBit=(((instr.next->memaddress)>>2)&1);//bit that determines first instruction in an entry is used
				
				if(instr.next->memaddress>=TOP){
				instr.next->instruction=intToBin(DATA[indexOfMem(instr.next->memaddress)]);
				}
				
				cache.set[setBit].entry[entryBit].Data[dataBit]=*instr.next;//assigns the second instruction
			}
			else if(lastTag==(instr.next->memaddress>>5) && setBit==setBitTestHack){//compares the tags of the following instruction to see if it is within the same memory block
				tag=(instr.next->memaddress>>5);
				tempTag=(tag>>1)+1;
				setBit=(instr.next->memaddress>>3&tempTag);//set bit for instruction set if >= 128
				dataBit=(((instr.next->memaddress)>>2)&1);//bit that determines first instruction in an entry is used
				
				if(instr.next->memaddress>=TOP){
				instr.next->instruction=intToBin(DATA[indexOfMem(instr.next->memaddress)]);
				}
				cache.set[setBit].entry[entryBit].Data[dataBit]=*instr.next;//assigns the second instruction
			}
			else if(lastTag==((instr.memaddress-4)>>5) && (setBit==((instr.memaddress-4)>>3&instr.memaddress-4)>>5)){//compares the tags of the last instruction to see if it is within the same memory block
				Instruction* lastInstr=HEAD;
				tag=((instr.memaddress-4)>>5);
				while(lastInstr->memaddress!=(instr.memaddress-4)){
					lastInstr=lastInstr->next;
				}
				if(lastInstr->memaddress >= 128){
				tempTag=(tag>>1)+1;
				setBit=(lastInstr->memaddress>>3&tempTag);//set bit for instruction set if >=128
				}
				else{
				setBit=(lastInstr->memaddress>>3&tag);//set bit for instruction set
				}
				dataBit=((lastInstr->memaddress>>2)&1);//bit that determines first instruction in an entry is used

				if(instr.next->memaddress>=TOP){
				lastInstr->instruction=intToBin(DATA[indexOfMem(lastInstr->memaddress)]);
				}
				
				cache.set[setBit].entry[entryBit].Data[dataBit]=*lastInstr;//assigns the second instruction

			}
			else{
				return;
			}

			}
		}
	bool cacheCheck(int memAddress){//CHECKS CACHE FOR INSTRUCTION AT MEMADDRESS RETURNS BOOL FOR SUCCESS
		int tempTag;
		int tag=memAddress>>5,
			dataBit=memAddress>>2&1;
		if(memAddress>=128){ 
				tempTag=(tag>>1)+1;
				setBit=(memAddress>>3&tempTag);//set bit for instruction set
			}

			else{
				setBit=(memAddress>>3&tag);//set bit for instruction set
			}
		for(int entrybit=0;entrybit<=1;entrybit++){
			if(cache.set[setBit].entry[entrybit].Data[dataBit].memaddress==memAddress){
			return true;
			}
		}
		return false;
		}
	int checkCache(int memAddress){//CHECKS CACHE FOR INSTRUCTION AT MEMADDRESS RETURNS INT FOR ENTRY BIT OR -1 FOR FAIL
			int tempTag;
			int tag=memAddress>>5,
			dataBit=memAddress>>2&1;

			if(memAddress>=128){
				tempTag=(tag>>1)+1;
				setBit=(memAddress>>3&tempTag);//set bit for instruction set
			}

			else{
				setBit=(memAddress>>3&tag);//set bit for instruction set
			}
		for(int entrybit=0;entrybit<=1;entrybit++){
			if(cache.set[setBit].entry[entrybit].Data[dataBit].memaddress==memAddress){
			return entrybit;
			}
		}
		return -1;
		}
	bool changeDirtyBit(int memAddress){
			int tempTag;
			if(cacheCheck(memAddress)){
				entryBit = checkCache(memAddress);
			}
			else{
				return false;
			}
			int tag=memAddress >> 5;//sets temp variable for tag

			if(memAddress>=128){ 
				tempTag=(tag>>1)+1;
				setBit=(memAddress>>3&tempTag);//set bit for instruction set
			}

			else{
				setBit=(memAddress>>3&tag);//set bit for instruction set
			}

			if(cache.set[setBit].entry[entryBit].dirtyBit){
				cache.set[setBit].entry[entryBit].dirtyBit=false;
			}
			else{
				cache.set[setBit].entry[entryBit].dirtyBit=true;
			}
		}
	Instruction* GetInstrFromCache(int memAddress){
		int tag=memAddress>>5,
			setBit=(memAddress>>3&tag),
			dataBit=memAddress>>2&1;
		for(int entrybit=0;entrybit<=1;entrybit++){
			if(cache.set[setBit].entry[entrybit].Data[dataBit].memaddress==memAddress){//checks to see if the memAddress of instr is in either entry
					cache.set[setBit].lruBit=(bool)entrybit;//updates LRU bit if there is a hit
			return &cache.set[setBit].entry[entrybit].Data[dataBit]; //returns the pointer to the correct instruction if there's a hit
			}
			/*if(cache.set[setBit].lruBit){
				cache.set[setBit].lruBit=false;
			}
			else{
				cache.set[setBit].lruBit=true;
			}*/
		}
		return NULL;
		}
	int indexOfMem(int m){
			return (m-TOP)/4;
		}
		bool SetPreIssue(Instruction* instr){
			int i=0;
			while(preIssueBuffer[i]!=NULL){
			i++;
			if(i==4){
				return false;
			}
			}
			preIssueBuffer[i]=instr;
			return true;
		}
		bool SetPreALU(Instruction* instr){
			int i=0;
			while(preAluQueue[i]!=NULL){
			i++;
			if(i==2){
				return false;
			}
			}
			preAluQueue[i]=instr;
			return true;
		}
		bool SetPreMem(Instruction* instr){
			int i=0;
			while(preMemQueue[i]!=NULL){
			i++;
			if(i==2){
				return false;
			}
			}
			preMemQueue[i]=instr;
			return true;
		}
		bool SetPostALU(Instruction* instr){
			if(postAluBuffer!=NULL){
				return false;
			}
			postAluBuffer=instr;
			return true;
		}
		bool SetPostMem(Instruction* instr){
			if(postMemBuffer!=NULL){
				return false;
			}
			postMemBuffer=instr;
			return true;
		}
		Instruction* GetPreIssue(int i,bool destroy){
			while(i<=3 && preIssueBuffer[i]==NULL){
			i++;
			}
			if(i==4){
				return NULL;
			}
			Instruction* ptr=preIssueBuffer[i];
			
			if(destroy)
			{
				preIssueBuffer[i] = NULL;
				while(i<3 && preIssueBuffer[i+1]!=NULL){
				preIssueBuffer[i]=preIssueBuffer[i+1];
				preIssueBuffer[i+1] = NULL;
				i++;
			}
			}
			return ptr;
		}
		Instruction* GetPreALU(){
			int i=0;
			while(i<=1 && preAluQueue[i]==NULL){
			i++;
			}
			if(i==2){
				return NULL;
			}
			Instruction* ptr=preAluQueue[i];
			preAluQueue[i]=NULL;
			if(i==0 && preAluQueue[1]!=NULL){
			preAluQueue[0]=preAluQueue[1];
			preAluQueue[1] = NULL;
			}
			return ptr;
		}
		Instruction* GetPreMem(){
			int i=0;
			while(i<=1 && preMemQueue[i]==NULL){
			i++;
			}
			if(i==2){
				return NULL;
			}
			Instruction* ptr=preMemQueue[i];
			preMemQueue[i]=NULL;
			if(i==0 && preMemQueue[1]!=NULL){
			preMemQueue[0]=preMemQueue[1];
			preMemQueue[1] = NULL;
			}
			return ptr;
		}
		Instruction* GetPostALU(){
			int i=1;
			while(i>=0 && postAluBuffer==NULL){
			i--;
			}
			if(i==-1){
				return NULL;
			}
			Instruction* ptr=postAluBuffer;
			postAluBuffer=NULL;
			return ptr;
		}
		Instruction* GetPostMem(){
			int i=1;
			while(i>=0 && postMemBuffer==NULL){
			i--;
			}
			if(i==-1){
				return NULL;
			}
			Instruction* ptr=postMemBuffer;
			postMemBuffer=NULL;
			return ptr;
		}
	};
}
#endif