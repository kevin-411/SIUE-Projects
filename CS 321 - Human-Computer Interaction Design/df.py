##
## Hey guys I wrote a quick python script because I was struggling
## with the new degrees of freedom (df) formula White gave to us.
## This is just a quick checker to make sure you're entering it in your
## calculator correctly. Just put the both standard deviations (s1, s2)
## and both numbers of participants in (n1, n2) problems 1 and 2 are already
## done for the hw assignment but if you wanna practice

class DegreesOfFreedom:

    def calculate(self, s1=0, s2=0, n1=0, n2=0):
        numerator = pow(pow(s1,2)/n1+pow(s2,2)/n2,2)
        denominator = pow(pow(s1, 2)/n1,2)/(n1-1) + pow(pow(s2, 2)/n2,2)/(n2-1)
        return numerator/denominator

df = DegreesOfFreedom()

print df.calculate(.84, 1.57, 12, 15) ## problem 1
print df.calculate(1.78, 3.03, 32, 27) ## problem 2
