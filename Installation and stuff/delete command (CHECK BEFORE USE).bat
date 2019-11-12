CD "C:\Users\mo2-bawk\Desktop\Softuni rep\TestFolder"
FOR /D /r %%f in (bin) DO ( 
del /S /Q "%%f\*"
RD /S /Q "%%f"
)
FOR /D /r %%f in (obj) DO ( 
del /S /Q "%%f\*" 
RD /S /Q "%%f"
)
FOR /D /r %%f in (.vs) DO ( 
del /S /Q "%%f\*" 
RD /S /Q "%%f"
)

set /p DUMMY=Hit ENTER to continue...