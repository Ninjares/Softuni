::Default CD is file location
::CD "C:\Users\mo2-bawk\Desktop\Softuni rep\C# tech fundamentals"
FOR /D /r %%G in (bin) DO Echo %%G
FOR /D /r %%G in (obj) DO Echo %%G
FOR /D /r %%G in (.vs) DO Echo %%G
set /p DUMMY=Hit ENTER to continue...