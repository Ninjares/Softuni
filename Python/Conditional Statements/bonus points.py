score = int(input())

bonus = float
if score<=100: bonus = 5
if score>100 and score <= 1000: bonus = score*0.2
if score>1000: bonus = score*0.1 ; 
if score%2 ==0: bonus += 1 ; 
if score%10==5: bonus += 2 ; 
print(f'{bonus}\n{score+bonus}')