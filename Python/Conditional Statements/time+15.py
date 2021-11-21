h = int(input())
m = int(input())

m+=15;
if m>=60: m-=60; h+=1
if h>=24: h-=24

if m<10: print(f'{h}:0{m}')
else: print(f'{h}:{m}')