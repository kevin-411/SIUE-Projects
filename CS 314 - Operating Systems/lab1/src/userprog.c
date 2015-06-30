extern int Putchar ();

main (int x)
{
  char	i;
  char	*str = "Letters";
  int pid;
  pid = GetPid();

  Printf("The process pid is %d\n", pid);
  Printf ("This is a test (%d,0x%x)\n", x, x);
  Open ("Process ID", x);
  for (i = 'a'; i <= 'z'; i++) {
    Open (str, i);
  }
}
