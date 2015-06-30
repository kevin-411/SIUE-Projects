#
# This is a makefile for the DLX OS projects.
#

CC = gcc-dlx
AS = dlxasm
CFLAGS = -mtraps -O3

#INCS = $(wildcard *.h)
#SRCS = $(wildcard *.c)
#OBJS = $(addsuffix .o, $(basename $(wildcard *.c))) \
#       $(addsuffix .o, $(basename $(wildcard *.s)))
INCS = dlxos.h traps.h filesys.h memory.h misc.h process.h queue.h \
        syscall.h share_memory.h
SRCS = filesys.c memory.c misc.c process.c queue.c traps.c sysproc.c
OBJS = $(addsuffix .o, $(basename $(SRCS)))

#all: os.dlx.obj  userprog4 userprog5 userprog6
all: os.dlx.obj userprog userprog4 userprog6 testprog userprog5 usertraps.s

part2: userprog4 userprog5 userprog6

os.dlx.obj: os.dlx
	$(AS) -i _osinit -l os.lst os.dlx
	mv os.dlx.obj ../execs

os.dlx: $(OBJS) dlxos.o trap_random.o osend.o share_memory.o synch.o
	$(CC) -mtraps -O3 dlxos.o trap_random.o share_memory.o synch.o $(OBJS) osend.o -o os.dlx

process.o: process.c process.h 
#	cat process.c helper > process.c.test
#	mv process.c.test process.c
	$(CC) -mtraps -O3 -c -o process.o process.c


share_memory.o: share_memory.api
	cp share_memory.api share_memory.o

synch.o: synch.bin
	cp synch.bin synch.o

osend.o: osend.s
	$(CC) -c osend.s

trap_random.o: trap_random.s
	$(CC) -c trap_random.s

dlxos.o: dlxos.s
	$(CC) -c dlxos.s

usertraps.o: usertraps.s
	cat usertraps.s trap_helper > usertraps.s.test
	mv usertraps.s.test usertraps.s
	$(CC) -c usertraps.s

testprog: testprog.o usertraps.o misc.o
	$(CC) -mtraps -O3 testprog.o usertraps.o misc.o -o testprog.dlx
	$(AS) -l testprog.lst testprog.dlx
	mv testprog.dlx.obj ../execs

userprog : userprog.o usertraps.o misc.o
	$(CC) -mtraps -O3 userprog.o usertraps.o misc.o -o userprog.dlx
	$(AS) -l userprog.lst userprog.dlx
	mv userprog.dlx.obj ../execs

userprog4 : userprog4.o usertraps.o misc.o
	$(CC) -mtraps -O3 userprog4.o usertraps.o misc.o -o userprog4.dlx
	$(AS) -l userprog4.lst userprog4.dlx
	mv userprog4.dlx.obj ../execs

userprog5 : userprog5.o usertraps.o misc.o
	$(CC) -mtraps -O3 userprog5.o usertraps.o misc.o -o userprog5.dlx
	$(AS) -l userprog5.lst userprog5.dlx
	mv userprog5.dlx.obj ../execs

userprog6 : userprog6.o usertraps.o misc.o
	$(CC) -mtraps -O3 userprog6.o usertraps.o misc.o -o userprog6.dlx
	$(AS) -l userprog6.lst userprog6.dlx
	mv userprog6.dlx.obj ../execs

Makefile.depend: depend

depend: $(SRCS) $(INCS)
	$(CC) -MM $(SRCS) > Makefile.depend

clean:
	/bin/rm -f *.o *.dlx *.lst *~ ../execs/*.obj Makefile.depend ../execs/vm

include Makefile.depend
