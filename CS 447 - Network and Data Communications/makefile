EXEC = server
OBJS = server.o

CC = g++

CFLAGS = -W -Wall

LIBS = 
LDFLAGS = 

$(EXEC): $(OBJS)
	$(CC) $(LDFLAGS) -o $@ $(OBJS) $(LIBS)

.PHONY: clean

clean:
	rm -f $(EXEC) $(OBJS) *~ 
