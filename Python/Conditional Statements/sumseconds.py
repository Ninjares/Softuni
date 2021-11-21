ft = int(input())
st = int(input())
ttd = int(input())
tt = ft+st+ttd
if tt-(tt//60)*60<10:
    print(f'{tt//60}:0{tt-(tt//60)*60}')
else:
    print(f'{tt//60}:{tt-(tt//60)*60}')