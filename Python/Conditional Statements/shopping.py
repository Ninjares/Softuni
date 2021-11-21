cash = float(input())
n = int(input())
m = int(input())
p = int(input())

total = (n*250 + m*(0.35*n*250) + p*(0.1*n*250))
if n>=m: total *=0.85
if cash - total>=0: print(f'You have {cash-total:0.2f} leva left!')
else: print(f'Not enough money! You need {(cash-total)*-1:0.2f} leva more!')