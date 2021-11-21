import math 

name = input()
budget = float(input())
beers = int(input())
crisps = int(input())

mleft = budget - (beers*1.2 + math.ceil(crisps*(beers*1.2*0.45)))

if mleft >= 0:
    print(f"{name} bought a snack and has {mleft:0.2f} leva left.")
elif mleft<0:
    print(f"{name} needs {mleft*-1:0.2f} more leva!")