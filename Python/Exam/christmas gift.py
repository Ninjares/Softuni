cinput = input()
kids = int(0)
adults = int(0)

while cinput != 'Christmas':
    age = int(cinput)
    if age<=16: kids+=1
    if age>16: adults+=1
    cinput = input()

print(f'Number of adults: {adults}')
print(f'Number of kids: {kids}')
print(f'Money for toys: {kids*5}')
print(f'Money for sweaters: {adults*15}')