locations = int(input())
for i in range(0, locations):
    expectedgold = float(input())
    days = int(input())
    totalgold = float(0)
    for j in range(0, days):
        goldToday = float(input())
        totalgold += goldToday
    if(totalgold/days >= expectedgold):
        print(f'Good job! Average gold per day: {totalgold/days:0.2f}.')
    else:
        print(f'You need {expectedgold-totalgold/days:0.2f} gold.')
