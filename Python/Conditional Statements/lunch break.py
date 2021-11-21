import math
series = input()
episodeLength = int(input())
BreakLength = int(input())

timeLeft = BreakLength - BreakLength/8 - BreakLength/4 - episodeLength
if timeLeft>=0: print(f'You have enough time to watch {series} and left with {math.ceil(timeLeft)} minutes free time.')
else: print(f'You don\'t have enough time to watch {series}, you need {math.ceil(timeLeft*-1)} more minutes.')