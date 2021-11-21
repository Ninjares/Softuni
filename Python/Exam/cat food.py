cats = int(input())

smallcats = int(0)
medcats = int(0)
chonkers = int(0)

totalGfood = float(0)

for i in range(0, cats):
    gfood = float(input())
    totalGfood += gfood
    if gfood >= 100 and gfood < 200: smallcats+=1
    if gfood >= 200 and gfood < 300: medcats+=1
    if gfood >= 300 and gfood < 400: chonkers+=1

print(f'Group 1: {smallcats} cats.')
print(f'Group 2: {medcats} cats.')
print(f'Group 3: {chonkers} cats.')

print(f'Price for food per day: {totalGfood/1000*12.45:0.2f} lv.')