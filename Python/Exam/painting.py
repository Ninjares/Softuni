import math

boxes = int(input())
rolls = int(input())
glovesPrice = float(input())
brushPrice = float(input())

totalPrice = boxes*21.5 + rolls*5.2 + math.ceil(rolls*0.35)*glovesPrice + math.floor(boxes*0.48)*brushPrice

print(f"This delivery will cost {totalPrice/15:0.2f} lv.")