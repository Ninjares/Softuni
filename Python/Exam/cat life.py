species = input()
gender = input()

years = int
years = 0

if species == 'British Shorthair':
    if gender == 'm':
        years = 13
    if gender == 'f':
        years = 14
elif species == 'Siamese':
    if gender == 'm':
        years = 15
    if gender == 'f':
        years = 16
elif species == 'Persian':
    if gender == 'm':
        years = 14
    if gender == 'f':
        years = 15
elif species == 'Ragdoll':
    if gender == 'm':
        years = 16
    if gender == 'f':
        years = 17
elif species == 'American Shorthair':
    if gender == 'm':
        years = 12
    if gender == 'f':
        years = 13
elif species == 'Siberian':
    if gender == 'm':
        years = 11
    if gender == 'f':
        years = 12
else: years = -1

if years == -1: print(f'{species} is invalid cat!')
else: print(f'{years*2} cat months')
